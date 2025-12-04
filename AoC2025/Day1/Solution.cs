namespace AoC2025.Day1;

public static class Solution
{
    public static async Task<int> Solve(string inputPath, int startPosition = 50, int dialSize = 100, bool trackAllHits = false)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(dialSize);

        if (startPosition < 0 || startPosition >= dialSize)
        {
            throw new ArgumentOutOfRangeException(nameof(startPosition), "startPosition must be within the dial range");
        }

        var nodes = InitNodes(startPosition, dialSize);
        
        var position = startPosition;
        var input = await File.ReadAllLinesAsync(inputPath);
        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line) || line.Length < 2)
            {
                continue;
            }

            var op = line[..1].ToUpperInvariant();
            if (!int.TryParse(line[1..], out var value) || value < 0)
            {
                continue;
            }

            // result = MathematicalSolution(position, op, value, result);
            // Console.WriteLine($"Current Position: {position}, Operation: {op}, Value: {value}, Node: {nodes[position]}");
            //position = TraverseNodes(nodes, position, op, value, dialSize);
            position = TraverseNodes(nodes, position, op, value, trackAllHits); 
        }

        return nodes[0].Hits;
    }

    private static Dictionary<int, Node> InitNodes(int startPosition, int dialSize)
    {
        var nodes = new Dictionary<int, Node>(dialSize);
        for (var i = 0; i < dialSize; i++)
        {
            nodes.Add(
                i,
                new Node
                {
                    NodeId = i,
                    PreviousNodeId = i - 1 < 0 ? dialSize - 1 : i - 1,
                    NextNodeId = i + 1 >= dialSize ? 0 : i + 1,
                    Hits = i == startPosition ? 1 : 0
                });
        }

        return nodes;
    }

    private static int TraverseNodes(Dictionary<int, Node> nodes, int pointer, string op, int value, bool trackAllHits)
    {
        var currentNode = nodes[pointer];
        while (value > 0)
        {
            currentNode = op switch
            {
                "L" => nodes[currentNode.PreviousNodeId],
                "R" => nodes[currentNode.NextNodeId],
                _ => throw new ArgumentException("Invalid operation")
            };

            value--;

            if (trackAllHits)
            {
                currentNode.Hits++;
            }
        }

        if (!trackAllHits)
        {
            currentNode.Hits++;
        }

        return currentNode.NodeId;
    }
    
    private static int TraverseNodes(Dictionary<int, Node> nodes, int pointer, string op, int value, int dialSize)
    {
        if (value == 0)
        {
            nodes[pointer].Hits++;
            return pointer;
        }

        var steps = value % dialSize;

        var newPosition = op switch
        {
            "L" => (pointer - steps + dialSize) % dialSize,
            "R" => (pointer + steps) % dialSize,
            _ => throw new ArgumentException("Invalid operation")
        };

        nodes[newPosition].Hits++;

        return newPosition;
    }
    
    private static int MathematicalSolution(int position, string op, int value, int result, int dialSize)
    {
        position = op switch
        {
            "L" => (position - value + dialSize) % dialSize,
            "R" => (position + value) % dialSize,
            _ => throw new ArgumentOutOfRangeException()
        };

        if (position == 0)
        {
            result++;
        }

        return result;
    }

    private static void PrintNodes(Dictionary<int, Node> nodes)
    {
        foreach (var keyValuePair in nodes)
        {
            Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value.NodeId}, Prev: {keyValuePair.Value.PreviousNodeId}, Next: {keyValuePair.Value.NextNodeId}, Hits: {keyValuePair.Value.Hits}");
        }
    }
}