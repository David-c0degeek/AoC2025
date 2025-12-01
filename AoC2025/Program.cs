using AoC2025.Day1;
using AwesomeAssertions;

namespace AoC2025;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        var result = await Part1.Solve("Day1/day1part1example.txt");
        result.Should().Be(3);
        
        // 1165
        var result1 = await Part1.Solve("Day1/day1part1input.txt");
        result1.Should().Be(1165);
        Console.WriteLine(result1);
        
        var result2 = await Part1.Solve("Day1/day1part1input.txt", trackAllHits: true);
        Console.WriteLine(result2);
    }
}