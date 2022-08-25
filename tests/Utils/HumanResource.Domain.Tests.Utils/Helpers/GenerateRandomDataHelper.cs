using System;
using System.Text;

namespace HumanResource.Domain.Tests.Utils.Helpers;

public static class GenerateRandomDataHelper
{
    private static readonly Random Random = new Random();

    public static int GenerateIntNumber()
    {
        return Random.Next(1, int.MaxValue);
    }
    public static long GenerateLongNumber()
    {
        return Random.NextInt64(1,long.MaxValue);
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

    public static DateTime GenerateRandomDate()
    {
        var generator = new Random();

        var start = DateTime.MinValue;

        var range = (DateTime.Today - start).Days;

        return start.AddDays(generator.Next(range));
    }

    private static long NextInt64(this Random rnd)
    {
        var buffer = new byte[sizeof(long)];
        rnd.NextBytes(buffer);
        return BitConverter.ToInt64(buffer, 0);
    }
}