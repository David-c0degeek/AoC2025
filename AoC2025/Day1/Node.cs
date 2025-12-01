namespace AoC2025.Day1;

public class Node
{
    public int NodeId { get; set; }
    public int PreviousNodeId { get; set; }
    public int NextNodeId { get; set; }
    public int Hits { get; set; }

    public override string ToString()
    {
        return $"NodeId: {NodeId}, PreviousNodeId: {PreviousNodeId}, NextNodeId: {NextNodeId}, Hits: {Hits}";
    }
}