using AwesomeAssertions;

namespace AoC2025;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        // await ExecuteDay1();
        // await ExecuteDay2();
        // await ExecuteDay3();
        await ExecuteDay4();
    }

    private static async Task ExecuteDay4()
    {
        var result = await Day4.Solution.Solve1("Day4/day4part1example.txt");
        result.Should().Be(13);
        
        var result1 = await Day4.Solution.Solve1("Day4/day4part1input.txt");
        result1.Should().Be(1551);
        
        var result2 = await Day4.Solution.Solve2("Day4/day4part1example.txt");
        result2.Should().Be(43);
        
        var result3 = await Day4.Solution.Solve2("Day4/day4part1input.txt");
        result3.Should().Be(9784);
    }

    private static async Task ExecuteDay3()
    {
        var result = await Day3.Solution.Solve1("Day3/day3part1example.txt");
        result.Should().Be(357);
        
        var result1 = await Day3.Solution.Solve1("Day3/day3part1input.txt");
        result1.Should().Be(16993);
        
        var result2 = await Day3.Solution.Solve2("Day3/day3part1example.txt");
        result2.Should().Be(3121910778619);
        
        var result3 = await Day3.Solution.Solve2("Day3/day3part1input.txt");
        result3.Should().Be(168617068915447);
    }

    private static async Task ExecuteDay2()
    {
        var result = await Day2.Solution.Solve1("Day2/day2part1example.txt");
        result.Should().Be(1227775554);
        
        var result2 = await Day2.Solution.Solve1("Day2/day2part1input.txt");
        result2.Should().Be(23560874270);
        
        var result3 = await Day2.Solution.Solve2("Day2/day2part1example.txt");
        result3.Should().Be(4174379265);
        
        var result4 = await Day2.Solution.Solve2("Day2/day2part1input.txt");
        result4.Should().Be(44143124633);
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