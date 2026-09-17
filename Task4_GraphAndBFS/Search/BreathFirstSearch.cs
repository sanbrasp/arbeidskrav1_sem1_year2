namespace Task4_GraphAndBFS.Search;

internal static class BreathFirstSearch
{
    /// <summary>
    /// Runs a Breadth-First Search on an array with a starting node.
    /// </summary>
    /// <param name="adjacencyList">The array to search in.</param>
    /// <param name="startNode">The starting node/point.</param>
    /// <returns></returns>
    internal static List<string> Bfs(Dictionary<string, List<string>> adjacencyList, string startNode)
    {
        HashSet<string> Visited = new();
        Queue<string> Queue = new();
        List<string> Result = new();
        
        if (!adjacencyList.ContainsKey(startNode))
        {
            return new List<string>();
        }
        
        Visited.Add(startNode);
        Queue.Enqueue(startNode);

        while (Queue.Count > 0) // while someone is waiting in the queue
        {
            var current = Queue.Dequeue(); // gives us the first node, removes it from the queue
            Result.Add(current); // current has been processed, added to result list, storing visit order

            if (adjacencyList.TryGetValue(current, out var neighbors))
            {
                foreach (var neighbor in neighbors) // current's neighbors
                {
                    if (!Visited.Contains(neighbor)) // if not visited, add to visited, skipped otherwise
                    {
                        Visited.Add(neighbor); // new neighbor marked visited immediately
                        Queue.Enqueue(neighbor); // new neighbors added to the back of queue
                    }
                }
            }
        }
        return Result;
    }
}