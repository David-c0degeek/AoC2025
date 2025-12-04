using System.Globalization;

namespace AoC2025.Day3;

public static class Solution
{
    public static async Task<long> Solve1(string inputPath)
    {
        var input = await File.ReadAllLinesAsync(inputPath);

        var banks = input
            .Select(numStr => numStr
                .ToCharArray()
                .Select(c => (long)(c - '0'))
                .ToList())
            .ToList();

        long result = 0;

        foreach (var battery in banks)
        {
            long highestNumber = 0;
            for (var i = 0; i < battery.Count; i++)
            {
                var currentNumber = battery[i];
                for (var j = i + 1; j < battery.Count; j++)
                {
                    var numberToCheck = currentNumber * 10 + battery[j];
                    if (numberToCheck > highestNumber)
                    {
                        highestNumber = numberToCheck;
                    }
                }
            }

            result += highestNumber;
        }

        return result;
    }
}