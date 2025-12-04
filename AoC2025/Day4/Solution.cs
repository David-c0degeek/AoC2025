namespace AoC2025.Day4;

public static class Solution
{
    private record Direction(int Row, int Column);

    private static readonly List<Direction> Directions =
    [
        new(-1, 0), // N
        new(-1, 1), // NE
        new(0, 1), // E
        new(1, 1), // SE
        new(1, 0), // S
        new(1, -1), // SW
        new(0, -1), // W
        new(-1, -1) // NW
    ];

    public static async Task<long> Solve1(string inputPath, int maxAdjacent = 4)
    {
        var grid = await ParseInput(inputPath);
        var totalRows = grid.Count;
        var totalColumns = grid[0].Count;
        
        var result = 0L;

        result = WorkWork(maxAdjacent, totalRows, totalColumns, grid, result);

        return result;
    }
    
    public static async Task<long> Solve2(string inputPath, int maxAdjacent = 4)
    {
        var grid = await ParseInput(inputPath);
        var totalRows = grid.Count;
        var totalColumns = grid[0].Count;
        
        var result = 0L;

        result = WorkWork(maxAdjacent, totalRows, totalColumns, grid, result, true);

        return result;
    }

    private static long WorkWork(int maxAdjacent, int totalRows, int totalColumns, List<List<int>> grid, long result,
        bool shouldRemove = false)
    {
        bool removed;

        do
        {
            removed = false;
            for (var i = 0; i < totalRows; i++)
            {
                for (var j = 0; j < totalColumns; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        continue;
                    }

                    var rollsFound = 0;
                    foreach (var direction in Directions)
                    {
                        if (IsInBounds(totalRows, totalColumns, i, j, direction))
                        {
                            if (grid[i + direction.Row][j + direction.Column] == 1)
                            {
                                rollsFound++;
                            }
                        }

                        if (rollsFound > maxAdjacent)
                        {
                            break;
                        }
                    }

                    if (rollsFound >= maxAdjacent) continue;

                    result++;

                    if (!shouldRemove) continue;
                    grid[i][j] = 0;
                    removed = true;
                }
            }
        } while (removed);


        return result;
    }

    private static bool IsInBounds(int totalRows, int totalColumns, int startRow, int startColumn,
        Direction direction)
    {
        if (startRow + direction.Row < 0) return false;
        if (startRow + direction.Row >= totalRows) return false;
        if (startColumn + direction.Column < 0) return false;
        if (startColumn + direction.Column >= totalColumns) return false;

        return true;
    }

    private static async Task<List<List<int>>> ParseInput(string inputPath)
    {
        var input = await File.ReadAllLinesAsync(inputPath);

        var rowCount = input.Length;

        var grid = new List<List<int>>(rowCount);

        grid.AddRange(input
            .Select(row => row
                .ToCharArray()
                .Select(x => x == '.' ? 0 : 1)
                .ToList()));

        return grid;
    }
}