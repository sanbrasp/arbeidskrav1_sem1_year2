namespace Task5_DFSAndComparison.SearchAlgorithms;

internal static class Search
{
    /// <summary>
    /// Runs a recursive Depth-First Search on an array.
    /// It also has an out var return value for catching the cycles records.
    /// </summary>
    /// <param name="adjacencyList">The array to perform the search on.</param>
    /// <param name="startNode">The start node.</param>
    /// <param name="cycles">Any discovered and recorded cycles.</param>
    /// <returns>An ordered visitation list.</returns>
    internal static List<string> RecursiveDfs
        (Dictionary<string, List<string>> adjacencyList, string startNode, out List<(string, string)> cycles)
    {
        if (!adjacencyList.ContainsKey(startNode))
        {
            cycles = new List<(string, string)>(); // define the "cycles" before returning
            return new List<string>();
        }
        
        cycles = new List<(string, string)>(); // parameter value assignment
        var visited = new HashSet<string>();
        var result =  new List<string>();
        string? previous = null;

        Recursion(adjacencyList, startNode, previous, visited, cycles, result); // run recursion logic
        
        return result; // returns the order of visits
    }

    private static void Recursion
        (Dictionary<string, List<string>> adjacencyList, string current, string? previous, 
            HashSet<string> visited, List<(string, string)> cycles, List<string> result)
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
                    Recursion(adjacencyList, neighbor, current, visited, cycles, result);
                }

                else if (neighbor != previous) // cycle detection (neighbor IS in visited)
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
}