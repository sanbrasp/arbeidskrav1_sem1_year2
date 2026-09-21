using System.Linq;

namespace Task5_DFSAndComparison.SearchAlgorithms;

internal static class Search
{
    /// <summary>
    /// Runs a recursive Depth-First Search on an array.
    /// </summary>
    /// <param name="adjacencyList">The array to perform the search on.</param>
    /// <param name="startNode">The start node.</param>
    /// <returns>An ordered visitation list.</returns>
    internal static List<string> RecursiveDfs
        (Dictionary<string, List<string>> adjacencyList, string startNode)
    {
        if (!adjacencyList.ContainsKey(startNode))
        {
            return new List<string>();
        }
        
        var visited = new HashSet<string>();
        var result =  new List<string>();
        string? previous = null;

        Recursion(adjacencyList, startNode, visited, result); // run recursion logic
        
        return result; // returns the order of visits
    }

    private static void Recursion
        (Dictionary<string, List<string>> adjacencyList, string current, 
            HashSet<string> visited, List<string> result)
    {
        if (visited.Contains(current))
        {
            return;
        }
        visited.Add(current); // adds the current "current" to visited before each recursion
        result.Add(current);

        if (adjacencyList.TryGetValue(current, out var neighbors))
        {
            foreach (var neighbor in neighbors)
            {
                if (!visited.Contains(neighbor)) // recurse into any unvisited neighbor
                {
                    Recursion(adjacencyList, neighbor, visited, result);
                }
            }
        }
    }

    /// <summary>
    /// DFS-based algorithm that detects cycles in the graph.
    /// </summary>
    /// <param name="adjacencyList">The array to search.</param>
    /// <param name="startNode">The starting node.</param>
    /// <param name="cycles">Discovered and recorded cycles.</param>
    /// <remarks>Avoids duplicate results caused by two-way connections.</remarks>
    internal static void DetectCycles(Dictionary<string, List<string>> adjacencyList, 
        string startNode, out List<(string, string)> cycles)
    {
        if (!adjacencyList.ContainsKey(startNode))
        {
            cycles = new List<(string, string)>(); // define the "cycles" before returning
            return;
        }
        cycles = new List<(string, string)>(); // parameter value assignment
        var visited = new HashSet<string>();
        var result =  new List<string>();
        string? previous = null;

        RecursionForCycles(adjacencyList, startNode, previous, visited, cycles, result);
    }

    private static void RecursionForCycles(Dictionary<string, List<string>> adjacencyList, string current,
        string? previous, HashSet<string> visited, List<(string, string)> cycles, List<string> result)
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
                    RecursionForCycles(adjacencyList, neighbor, current, visited, cycles, result);
                }
                else if (neighbor != previous)
                {
                    bool alreadyRecorded = cycles.Any(
                        edge => edge == (neighbor, current)
                                || edge == (current, neighbor)); // avoid duplicate results in cycles record (two-way)
                    
                    if (!alreadyRecorded) // only add to cycles if not already recorded
                    {
                        cycles.Add((neighbor, current));
                    }
                }
            }
        }
    }

    /// <summary>
    /// Runs an iterative DFS traversal on a chosen array.
    /// </summary>
    /// <param name="adjacencyList">The array to perform the traversal on.</param>
    /// <param name="startNode">The node to start from.</param>
    /// <returns>A list ordered by time visited.</returns>
    internal static List<string> IterativeDfs // Stack, push, pop, peek. Use Stack<string>
        (Dictionary<string, List<string>> adjacencyList, string startNode)
    {
        if (!adjacencyList.ContainsKey(startNode))
        {
            return new List<string>();
        }
        
        var visited = new HashSet<string>();
        var result = new List<string>();
        string? current = null;
        Stack<string> stack = new Stack<string>();
        
        stack.Push(startNode);
        visited.Add(startNode);
        
        while (stack.Count > 0)
        {
            current = stack.Pop();
            result.Add(current);
            
            if (adjacencyList.TryGetValue(current, out var neighbors))
            {
                foreach (var neighbor in neighbors.AsEnumerable().Reverse())
                {
                    if (!visited.Contains(neighbor))
                    {
                        stack.Push(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }
        }
        return result;
    }
}