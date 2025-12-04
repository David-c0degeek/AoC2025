using System.Globalization;

namespace AoC2025.Day2;

public static class Solution
{
    public static async Task<double> Solve1(string inputPath)
    {
        var input = await File.ReadAllLinesAsync(inputPath);

        var ids = ParseRanges(input);

        double result = 0;

        foreach (var id in ids)
        {
            var left = id[..(id.Length / 2)];
            var right = id[(id.Length / 2)..];

            if (!left.Equals(right))
            {
                continue;
            }

            result += double.Parse(id);
        }

        return result;
    }
    
    public static async Task<double> Solve2(string inputPath)
    {
        var input = await File.ReadAllLinesAsync(inputPath);

        var ids = ParseRanges(input);

        double result = 0;
        
        foreach (var id in ids)
        {
            var len = id.Length;

            var found = false;
            for (var i = 1; i < len / 2 + 1; i++)
            {
                var toCheck = id[..i];

                if (len % toCheck.Length != 0)
                {
                    continue;
                }
                
                var chunks = new List<string>();
                for (var j = 0; j < len; j += toCheck.Length)
                {
                    chunks.Add(id.Substring(j, toCheck.Length));
                }

                if (!chunks.All(c => c.Equals(toCheck)))
                {
                    continue;
                }

                found = true;
                break;
            }
            
            if (found)
            {
                result += double.Parse(id);
            }
        }

        return result;
    }

    private static List<string> ParseRanges(string[] input)
    {
        var result = new List<string>();

        foreach (var line in input)
        {
            var segments = line.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var segment in segments)
            {
                result.AddRange(ExpandRange(segment));
            }
        }

        return result;
    }

    private static IEnumerable<string> ExpandRange(string range)
    {
        var parts = range.Split('-', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != 2 ||
            !double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out var start) ||
            !double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out var end) ||
            start > end)
        {
            throw new FormatException($"Invalid range format: {range}");
        }

        foreach (var x in DoubleRange(start, end, 1))
        {
            yield return x.ToString(CultureInfo.InvariantCulture);
        }
    }


    private static IEnumerable<double> DoubleRange(double start, double end, double step)
    {
        for (var x = start; x <= end; x += step)
        {
            yield return x;
        }
    }
}