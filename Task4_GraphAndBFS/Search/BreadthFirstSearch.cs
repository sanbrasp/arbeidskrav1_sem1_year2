namespace Task4_GraphAndBFS.Search;

internal static class BreadthFirstSearch
{
    /// <summary>
    /// Runs a Breadth-First Search on an array with a starting node.
    /// </summary>
    /// <param name="adjacencyList">The array to search in.</param>
    /// <param name="startNode">The starting node/point.</param>
    /// <returns>A list of visited nodes in order.</returns>
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
    
    /// <summary>
    /// Returns the shortest path from a starting node to a target node.
    /// </summary>
    /// <param name="adjacencyList">The array to search in.</param>
    /// <param name="start">The starting node.</param>
    /// <param name="target">The target node.</param>
    /// <returns>The shortest amount of steps from start to stop.</returns>
    internal static int ShortestPath
        (Dictionary<string, List<string>> adjacencyList, string start, string target)
    {
        HashSet<string> visited = new();
        Queue<string> queue = new();
        Dictionary<string, int> distances = new();
        int noResult = -1;

        if (!adjacencyList.ContainsKey(start) || !adjacencyList.ContainsKey(target))
        {
            return noResult;
        }

        visited.Add(start);
        queue.Enqueue(start);
        distances[start] = 0; // set start's distance to itself to 0

        while (queue.Count > 0)
        {
            // catch the current key in a variable and dequeue
            var current =  queue.Dequeue();
            
            if (current == target)
            {
                return distances[target];
            }
            
            // try to find the value stored under the key "current", and put it into variable called "neighbors"
            if (adjacencyList.TryGetValue(current, out var neighbors))
            {
                foreach (var neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                        distances[neighbor] = distances[current] + 1; // increment distance from current to neighbor
                    }
                }
            }
        }
        return noResult;
    }
}