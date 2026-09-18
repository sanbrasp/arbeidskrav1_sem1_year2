namespace Task4_GraphAndBFS.Search;

internal static class BreadthFirstSearch
{
    /// <summary>
    /// Runs a Breadth-First Search on an array with a starting node.
    /// </summary>
    /// <param name="adjacencyList">The array to search in.</param>
    /// <param name="startNode">The starting node/point.</param>
    /// <returns></returns>
    internal static List<string> Bfs(Dictionary<string, List<string>> adjacencyList, string startNode)
    {
        HashSet<string> visited = new();
        Queue<string> queue = new();
        List<string> result = new();
        
        if (!adjacencyList.ContainsKey(startNode))
        {
            return new List<string>();
        }
        
        visited.Add(startNode);
        queue.Enqueue(startNode);

        while (queue.Count > 0) // while someone is waiting in the queue
        {
            var current = queue.Dequeue(); // gives us the first node, removes it from the queue
            result.Add(current); // current has been processed, added to result list, storing visit order

            if (adjacencyList.TryGetValue(current, out var neighbors))
            {
                foreach (var neighbor in neighbors) // current's neighbors
                {
                    if (!visited.Contains(neighbor)) // if not visited, add to visited, skipped otherwise
                    {
                        visited.Add(neighbor); // new neighbor marked visited immediately
                        queue.Enqueue(neighbor); // new neighbors added to the back of queue
                    }
                }
            }
        }
        return result;
    }
    
    internal static int ShortestPath
        (Dictionary<string, List<string>> adjacencyList, string start, string target)
    {
        HashSet<string> visited = new();
        Queue<string> queue = new();
        Dictionary<string, int> distances = new();
        int result = -1;

        if (!adjacencyList.ContainsKey(start))
        {
            return result;
        }

        visited.Add(start);
        queue.Enqueue(start);
        distances[start] = 0;

        while (queue.Count > 0)
        {
            var current =  queue.Dequeue();
            // visited.Add(current);

            if (current == target)
            {
                return distances[target];
            }
            
            if (adjacencyList.TryGetValue(current, out var neighbors))
            {
                foreach (var neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                        distances[neighbor] = distances[current] + 1;
                    }
                }
            }
        }
        return result;
    }
}