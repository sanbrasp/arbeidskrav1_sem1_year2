namespace Task5_DFSAndComparison.SearchAlgorithms;

internal static class Search
{
    internal static List<string> RecursiveDfs
        (Dictionary<string, List<string>> adjacencyList, string startNode, out List<(string, string)> cycles)
    {
        if (!adjacencyList.ContainsKey(startNode))
        {
            cycles = new List<(string, string)>();
            return new List<string>();
        }
        
        cycles = new List<(string, string)>();
        var visited = new HashSet<string>();
        var result =  new List<string>();
        string? previous = null;

        Recursion(adjacencyList, startNode, previous, visited, cycles, result);
        
        return result;
    }

    private static void Recursion
        (Dictionary<string, List<string>> adjacencyList, string current, string? previous, 
            HashSet<string> visited, List<(string, string)> cycles, List<string> result)
    {
        if (visited.Contains(current))
        {
            return;
        }
        visited.Add(current);
        result.Add(current);

        if (adjacencyList.TryGetValue(current, out var neighbors))
        {
            foreach (var neighbor in neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    Recursion(adjacencyList, neighbor, current, visited, cycles, result);
                }

                else if (visited.Contains(neighbor) && neighbor != previous)
                {
                    cycles.Add((neighbor, current));
                }
            }
        }
    }
}