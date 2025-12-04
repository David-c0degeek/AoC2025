using System.Globalization;

namespace AoC2025.Day2;

public static class Solution
{
    public static async Task<long> Solve1(string inputPath)
    {
        var input = await File.ReadAllLinesAsync(inputPath);

        var ids = ParseRanges(input);
        
        return ids
            .Where(HasTwoEqualHalves)
            .Sum(id => long.Parse(id, CultureInfo.InvariantCulture));
    }
    
    private static bool HasTwoEqualHalves(string id)
    {
        var half = id.Length / 2;
        if (id.Length % 2 != 0) return false;

        var left = id[..half];
        var right = id[half..];

        return string.Equals(left, right, StringComparison.Ordinal);
    }
    
    public static async Task<long> Solve2(string inputPath)
    {
        var input = await File.ReadAllLinesAsync(inputPath);
        var ids = ParseRanges(input);

        return ids
            .Where(IsMadeOfRepeatingSubstring)
            .Sum(id => long.Parse(id, CultureInfo.InvariantCulture));
    }

    
    private static bool IsMadeOfRepeatingSubstring(string id)
    {
        var len = id.Length;

        for (var i = 1; i <= len / 2; i++)
        {
            var toCheck = id[..i];

            if (len % toCheck.Length != 0)
            {
                continue;
            }

            var allMatch = true;
            for (var j = 0; j < len; j += toCheck.Length)
            {
                if (!id.AsSpan(j, toCheck.Length).SequenceEqual(toCheck))
                {
                    allMatch = false;
                    break;
                }
            }

            if (allMatch)
            {
                return true;
            }
        }

        return false;
    }


    private static List<string> ParseRanges(string[] input)
    {
        var result = new List<string>();

        foreach (var line in input)
        {
            var segments = line
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim());

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
            !long.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out var start) ||
            !long.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out var end) ||
            start > end)
        {
            throw new FormatException($"Invalid range format: {range}");
        }

        foreach (var x in LongRange(start, end))
        {
            yield return x.ToString(CultureInfo.InvariantCulture);
        }
    }


    private static IEnumerable<long> LongRange(long start, long end)
    {
        for (var x = start; x <= end; x++)
        {
            yield return x;
        }
    }

}