# Task 4 - Graph and BFS


DELETE WHEN FINISHED:  
Model a small, undirected transport network as a graph. Stations are nodes, connections are edges. Use BFS to visit 
all reachable stations from a starting station, and to find the shortest number of stops in the unweighted graph.  

Mark completed with: ✅ 

- ✅ Design a Graph class that stores the network as an adjacency list (example: `Dictionary<string, List<string>>`)
- ✅ Implement `void AddConnection(string stationA, string stationB)` that adds a two-way connection
- ✅ Implement BFS traversal (needs a queue and separate visited tracking)
- ✅ Implement a BFS method that returns the shortest number of edges/stops between two stations. 
- ✅ Clearly define and document the return value when no route exists.
- ✅ Handle a missing start or target station without the program terminating uncontrolled (i.e. without crashing!)
- ?? Document the required test graph's edges explicitly (or build your own)
- ✅ Run and document BFS from Majorstuen
- Explain the complexity `O(V + E)` and why the `FIFO` order means BFS finds the shortest number of stops in an 
  unweighted graph.
- ✅ Tests (BFS from Majorstuen, document visit order, shortest number of stops )
- Document the neighbor-order (when a node has multiple neighbors, the visit order may vary depending on storage order)
- (don't forget to update the [commit history document](../Docs/CommitHistory.md))

---

## Overview
- [Implementation](#implementation)
  - [Graph Class](#graph-class)
  - [BFS](#breadthfirstsearch-method)
    - [ShortestPath](#shortestpath)
- [Tests](#tests)
- [Explanation](#explanation)
- [Bug Fixing](#bug-fixing)
- [Sources](#sources)

---

## Implementation
### Graph Class
Class setup:

```csharp
namespace Task4_GraphAndBFS.Models;

internal class Graph
{
    private readonly Dictionary<string, List<string>> _adjacencyList = new();
    
    internal void AddConnection(string stationA, string stationB)
    {
        AddNode(stationA);
        AddNode(stationB);
        
        _adjacencyList[stationA].Add(stationB);
        _adjacencyList[stationB].Add(stationA);
    }
    
    private void AddNode(string node)
    {
        if (!_adjacencyList.ContainsKey(node))
        {
            _adjacencyList[node] = new List<string>();
        }
    }
    
    internal Dictionary<string, List<string>> GetAdjacencyList()  
    {
        Dictionary<string, List<string>> adjacencyListCopy = new();
        foreach (var key in _adjacencyList)
        {
            adjacencyListCopy.Add(key.Key, new List<string>(key.Value));
        }

        return adjacencyListCopy;
    }
}
```
Holds an adjacency list, and the methods `AddConnection()`, `AddNode()`, and `GetAdjacencyList()`.  
`AddNode()` is only called within the class and is therefore set to `private`.  
`AddStation()` calls `AddNode()`, and can be called from elsewhere in the assembly.  
`GetAdjacencyList()` returns a deep copy of the original list, keeping it safe from corruption.

### BreadthFirstSearch Method
BFS method setup:

```csharp
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

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            result.Add(current);

            if (adjacencyList.TryGetValue(current, out var neighbors))
            {
                foreach (var neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
        return result;
    }
```
Tracks `visited` nodes using a `HashSet`.  
Uses a `Queue` in order to keep track of who is next up for processing.  
Stores the visitation order in a `List` of strings. 

Base case: `while someone is still waiting in the queue -> go on`.

Discovered nodes are immediately added to `visited`.  
Neighbors are enqueued.  

Guards against `if (!adjacencyList.ContainsKey(startNode)` and exits if the startnode doesn't exist in the array. 
Guards against `if (!visited.Contains(neighbor)` and ensures unvisited nodes gets added.  

Returns a list of processed visits in the order they were visited in.

---

### ShortestPath
ShortestPath method setup:

```csharp
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
        distances[start] = 0;

        while (queue.Count > 0)
        {
            var current =  queue.Dequeue();
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
        return noResult;
    }
```
Is a modified `Bfs()`, that stops when the condition `current == target` becomes true.  
It doesn't exhaust the array if it finds the target prior.  

Like `Bfs()` is uses a `HashSet` for visited and a `Queue` for the queue.  
It also uses a `Dictionary<string, int> distances` to keep track of the actual steps from start to target.  
Set up with a sentinel value (`-1`) for missing start or missing target, and returns that whenever either is missing.

Guards against `!adjacencyList.ContainsKey(start) || !adjacencyList.ContainsKey(target)`, and exists if either are true.

---

## Tests
Test screenshot, test names, test cases, why tests

---

## Explanation
What?

---

## Bug Fixing
I had initially set up `ShortestPath()` with a redundant .Add line: `visited.Add(current)` right after 
dequeue of `current`.  
I was returning the wrong `distances[]` and initially set it to `distances[start]`, which rendered the output useless as it 
would always be `0`.

In `Bfs()` I had a missing `result.Add(current)` after dequeue of `current`, which gave me the corrupt results when 
running the code.

---

## Sources
Any external sources here