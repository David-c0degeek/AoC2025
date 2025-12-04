using AwesomeAssertions;

namespace AoC2025;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        // await ExecuteDay1();
        await ExecuteDay2();
    }

    private static async Task ExecuteDay2()
    {
        var result = await Day2.Solution.Solve("Day2/day2part1example.txt");
        result.Should().Be(1227775554);
        
        var result2 = await Day2.Solution.Solve("Day2/day2part1input.txt");
        result2.Should().Be(23560874270);
    }

    private static async Task ExecuteDay1()
    {
        var result = await Day1.Solution.Solve("Day1/day1part1example.txt");
        result.Should().Be(3);
        
        // 1165
        var result1 = await Day1.Solution.Solve("Day1/day1part1input.txt");
        result1.Should().Be(1165);
        Console.WriteLine(result1);
        
        var result2 = await Day1.Solution.Solve("Day1/day1part1input.txt", trackAllHits: true);
        Console.WriteLine(result2);
    }
}