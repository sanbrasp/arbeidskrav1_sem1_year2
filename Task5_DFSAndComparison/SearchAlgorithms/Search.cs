namespace Task5_DFSAndComparison.SearchAlgorithms;

internal static class Search
{
    internal static List<string> RecursiveDfs
        (Dictionary<string, List<string>> adjacencyList, string startNode)
    {
        if (!adjacencyList.ContainsKey(startNode))
        {
            return new List<string>();
        }
        
        var visited = new HashSet<string>();
        var result =  new List<string>();
        var cycles = new List<(string, string)>();

        Recursion(adjacencyList, startNode, visited, cycles, result);
        
        return result;
    }

    private static void Recursion
        (Dictionary<string, List<string>> adjacencyList, string node, 
            HashSet<string> visited, List<(string, string)> cycles, List<string> result)
    {
        visited.Add(node);
        result.Add(node);
    }
}