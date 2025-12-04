using System.Globalization;

namespace AoC2025.Day3;

public static class Solution
{
    public static async Task<long> Solve1(string inputPath)
    {
        var banks = await ParseInput(inputPath);

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

    private static async Task<List<List<long>>> ParseInput(string inputPath)
    {
        var input = await File.ReadAllLinesAsync(inputPath);

        var banks = input
            .Select(numStr => numStr
                .ToCharArray()
                .Select(c => (long)(c - '0'))
                .ToList())
            .ToList();
        return banks;
    }

    public static async Task<long> Solve2(string inputPath, int batterySize = 12)
    {
        var banks = await ParseInput(inputPath);

        return banks
            .Where(b => b.Count >= batterySize)
            .Select(battery => MaxSubsequence(battery, batterySize))
            .Select(ConvertRangeToNumber)
            .Sum();
    }

    private static List<long> MaxSubsequence(List<long> battery, int batterySize)
    {
        var toRemove = battery.Count - batterySize;
        var stack = new List<long>(battery.Count);

        foreach (var d in battery)
        {
            while (toRemove > 0 && stack.Count > 0 && stack[^1] < d)
            {
                stack.RemoveAt(stack.Count - 1);
                toRemove--;
            }

            stack.Add(d);
        }

        if (stack.Count > batterySize)
        {
            stack.RemoveRange(batterySize, stack.Count - batterySize);
        }

        return stack;
    }
    
    private static long ConvertRangeToNumber(List<long> range)
    {
        return range.Aggregate<long, long>(0, (current, l) => current * 10 + l);
    }
}