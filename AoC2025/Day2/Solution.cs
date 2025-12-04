using System.Globalization;

namespace AoC2025.Day2;

public static class Solution
{
    public static async Task<double> Solve(string inputPath)
    {
        var input = await File.ReadAllLinesAsync(inputPath);
        
        var ranges = ParseRanges(input);

        double result = 0;
        
        foreach (var range in ranges)
        {
            foreach (var str in range)
            {
                var left = str[..(str.Length / 2)];
                var right = str[(str.Length / 2)..];

                if (!left.Equals(right))
                {
                    continue;
                }
                
                result += double.Parse(str);
            }
            
        }
        
        return result;
    }

    private static List<List<string>> ParseRanges(string[] input)
    {
        var ranges = input
            .SelectMany(line => line
                .Split(',', StringSplitOptions.RemoveEmptyEntries))
            .Select(range =>
            {
                var parts = range.Split('-', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2 ||
                    !double.TryParse(parts[0], out var start) ||
                    !double.TryParse(parts[1], out var end) ||
                    start > end)
                {
                    throw new FormatException($"Invalid range format: {range}");
                }

                return DoubleRange(start, end, 1)
                    .Select(x => x.ToString(CultureInfo.InvariantCulture))
                    .ToList();
            })
            .ToList();
        return ranges;
    }

    private static IEnumerable<double> DoubleRange(double start, double end, double step)
    {
        for (var x = start; x <= end; x += step)
        {
            yield return x;
        }
    }

}