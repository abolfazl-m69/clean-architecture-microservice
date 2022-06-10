using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace HumanResource.Framework.Application.EnumHelper
{
    public static class EnumExtension
    {
        public static List<KeyValuePair<int, string>> ToSelectList(this Enum enumValue)
        {
            return (from Enum enumType in Enum.GetValues(enumValue.GetType())
                    select new KeyValuePair<int, string>((int)Enum.Parse(enumType.GetType(), enumType.ToString()), enumType.GetEnumDescription()))
                .OrderBy(row => row.Value).ToList();
        }

        public static string GetEnumDescription(this Enum value)
        {
            if (value is null) return string.Empty;
            var attributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString())?.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes?.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}