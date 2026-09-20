namespace Task5_DFSAndComparison.SearchAlgorithms;

internal static class Search
{
    private static HashSet<string> _visited;
    private static List<string> _results;

    internal void ResetAndRunRecursiveDfs(Dictionary<string, List<string>> adjacencyList, string startNode)
    {
        ResetVisited();
        ResetResults();
        
        RecursiveDfs();
    }
    
    internal static List<string> RecursiveDfs
        (Dictionary<string, List<string>> adjacencyList, string current, string previous, HashSet<string> visited)
    {
        _visited = null;
        _results = null;
        
        
    }


    private static void ResetVisited()
    {
        _visited = null;
    }
    
    private static void ResetResults()
    {
        _results = null;
    }
}