#region Using
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
#endregion

namespace HumanResource.Framework.Common.Extensions
{
    public static class TypeExtension
    {
        #region Methods

        #region To Int & Double & Long & Float

        public static int ToInt(this Enum value)
        {
            return Convert.ToInt32(value);
        }

        public static int ToInt(this object value)
        {
            if (value == null)
                return 0;
            int.TryParse(value.ToString(), out var result);
            return result;
        }
        public static decimal ToDecimal(this object value)
        {
            if (value == null)
                return 0;
            decimal.TryParse(value.ToString(), out var result);
            return Math.Round(result, 2);
        }
        public static double ToDouble(this object value)
        {
            if (value == null)
                return 0;
            Double.TryParse(value.ToString(), out var result);
            return result;
        }
        public static long ToLong(this object value)
        {
            if (value == null)
                return 0;
            long.TryParse(Math.Round(value.ToDouble(), 0).ToString(CultureInfo.InvariantCulture), out var result);
            return result;
        }
        public static short ToShort(this object value)
        {
            if (value == null)
                return 0;
            short.TryParse(Math.Round(value.ToDouble(), 0).ToString(CultureInfo.InvariantCulture), out var result);
            return result;
        }

        public static float ToFloat(this object value)
        {
            if (value == null)
                return 0;
            float.TryParse(value.ToString(), out var result);
            return result;
        }

        #endregion

        #region To Byte

        public static byte[] ToByte(this IFormFile file)
        {
            if (file == null)
                return null;

            using var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        #endregion

        #region Get String

        public static string GetDefultStringValue(this object value) => value?.ToString() ?? "-";

        #endregion

        #region To Boolean

        public static bool ToBoolean(this object value)
        {
            if (value == null)
                return false;
            bool.TryParse(value.ToString(), out var result);
            return result;
        }

        #endregion

        #region To Guid

        public static Guid ToGuid(this object value)
        {
            if (value == null)
                return Guid.Empty;
            Guid.TryParse(value.ToString(), out var result);
            return result;
        }

        #endregion

        #region ToCurrency

        public static string ToCurrency(this decimal value) => $"{value.ToString("N0", CultureInfo.InvariantCulture)} ریال";

        #endregion

        #region To LowerWithTrim

        public static string ToLowerWithTrim(this string value) => value.Trim().ToLower();

        #endregion

        #region Format File Size : "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"

        public static string ToFileSize(this long fileLength)
        {
            var sizeSuffixes = new[] { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            if (fileLength < 0) { return $"-{ToFileSize(-fileLength)}"; }

            var index = 0;
            while (Math.Round(((decimal)fileLength) / 1024) >= 1)
            {
                fileLength /= 1024;
                index++;
            }
            return $"{fileLength:n1} {sizeSuffixes[index]}";
        }

        #endregion

        #region Get Size

        public static void GetSize(this string value, out int width, out int height)
        {
            if (string.IsNullOrEmpty(value))
            {
                width = 0;
                height = 0;
            }
            else
            {
                var size = value.Split(',');
                width = size[0].ToInt();
                height = size[1].ToInt();
            }
        }

        #endregion

        #region Convert Date Time ToString

        public static string DateToString(this DateTime date)
        {
            return date.ToString("yyyyMMdd");
        }

        public static string TimeToString(this DateTime date)
        {
            return date.ToString("HH:mm:ss tt zz");
        }

        #endregion

        #endregion

        public static List<Tuple<string, string>> GetFileType()
        {
            return new List<Tuple<string, string>>
            {
                new Tuple<string, string>("IVBOR", ".png"),
                new Tuple<string, string>("/9J/4", ".jpg"),
                new Tuple<string, string>("JVBER", ".pdf"),
                new Tuple<string, string>("UMFYI", ".rar"),
                new Tuple<string, string>("U1PKC", ".txt"),
            };
        }

        public static bool MimeTypeValidation(this string base64String)
        {
            if (string.IsNullOrWhiteSpace(base64String.ToMimeType()))
                return false;
            return true;
        }

        public static byte[] ToByte(this string base64String)
        {
            var fileString = base64String.Split(',')[1];
            return Convert.FromBase64String(fileString);
        }

        public static string ToMimeType(this string base64String)
        {
            if (string.IsNullOrWhiteSpace(base64String)) return string.Empty;

            var fileString = base64String.Split(',')[1];

            var data = fileString.Substring(0, 5);

            return GetFileType()
                .Where(r => r.Item1 == data.ToUpper())
                .Select(r => r.Item2).FirstOrDefault();
        }

        public static string ToJalaliDateString(this DateTime date)
        {
            var pc = new PersianCalendar();

            return string.Format("{0:0000}/{1:00}/{2:00}", pc.GetYear(date), pc.GetMonth(date), pc.GetDayOfMonth(date));
        }

        public static DateTime ToGregorianDate(this string persianDate)
        {
            return DateTime.Parse(persianDate, new CultureInfo("fa-IR"));
        }

        public static bool IsAValidNationalCode(this string nationalCode)
        {
            if (string.IsNullOrEmpty(nationalCode))
                return false;

            if (nationalCode.Length != 10)
                return false;

            var regex = new Regex(@"\d{10}");

            if (!regex.IsMatch(nationalCode))
                return false;

            if (nationalCode.Distinct().Count() == 1)
                return false;

            var chArray = nationalCode.ToCharArray();
            var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
            var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
            var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
            var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
            var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
            var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
            var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
            var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
            var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
            var a = Convert.ToInt32(chArray[9].ToString());

            var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
            var c = b % 11;

            return (((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a)));
        }

    }
}
