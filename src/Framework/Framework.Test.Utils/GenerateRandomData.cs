using System;
using System.Text;

namespace HumanResource.Framework.Test.Utils
{
    public static class GenerateRandomData
    {
        private static readonly Random Random = new Random();

        public static int GenerateIntNumber()
        {
            return Random.Next(1, int.MaxValue);
        }
        public static long GenerateLongNumber()
        {
            return Random.NextInt64();
        }

        public static string GenerateString()
        {
            var builder = new StringBuilder();

            var legalCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var size = new Random().Next(1, 15);

            for (var i = 0; i < size; i++)
            {
                var character = legalCharacters[Random.Next(0, legalCharacters.Length)];
                builder.Append(character);
            }

            return builder.ToString();
        }

        public static Int64 NextInt64(this Random rnd)
        {
            var buffer = new byte[sizeof(Int64)];
            rnd.NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }
    }
}