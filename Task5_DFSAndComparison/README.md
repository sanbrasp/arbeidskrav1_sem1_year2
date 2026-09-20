# Task 5 - DFS and Comparison
DFS, and comparison with BFS.

DELETE WHEN FINISHED:   
Bullet list: 
1. Reuse the Task 4 graph — same test graph, same edges, same Graph class.
2. Implement recursive DFS — needs a visited-tracking structure; needs a defined base step and recursive step.
3. Implement iterative DFS — must specifically use Stack<string>, not recursion.
4. Both variants must return or print visit order from a given start station.
5. Handle cycles — the graph must not infinite-loop if a cycle exists.
6. Handle isolated nodes — same isolated-station concept from Task 4.
7. Handle a missing start station gracefully.
8. Choose one extension: either (a) a route-exists-between-two-nodes method, or (b) a cycle-detection method for the undirected graph. Only one is required.
9. Explain base step and recursive step for the recursive DFS specifically.
10. Explain O(V+E) for DFS.
11. Explain recursive vs. iterative DFS — the differences between them.
12. Explain stack overflow risk for very deep graphs (recursive-specific risk).
13. Compare BFS vs. DFS — data structure used, method of visiting, memory use, and which problems each is best suited for.
14. Test: run both DFS variants from Majorstuen, compare their order against Task 4's BFS order.
15. Test the isolated station — behavior depends on which extension you picked (no-route test if you chose connectivity; if you chose cycle detection, this isolated-station test isn't explicitly tied to it, worth noting).
16. If you chose cycle detection: add an edge that creates a cycle, test that it's detected; also test a graph without a cycle for contrast.
17. Document how neighbor order and stack insertion order affect visit order — parallel to Task 4's neighbor-order documentation requirement.


_Note to self about cycle:  
- a cycle is a loop, a ring
- you come back to a point you've already been to
- if you get back to a place you've already been when traversing a new path, you have a cycle
- if you look at your neighbors, one of them HAS to be the one you just left, and if the 
  other ones are marked as `visited`, you have a cycle._

_Note to self about recursive DFS:  
- it needs to know the value of `previous` and `current`
- when recursing deeper, the value from `current` needs to be assigned to `previous`, because 
  each recursive call's `current` becomes the next call's `previous`

---

## Overview
- [Implementation](#implementation)
  - [Recursive DFS](#recursive-dfs)
  - [Iterative DFS](#iterative-dfs)
  - [Extension](#extension)
- [Tests](#tests)
- [Comparison](#comparison)
- [Sources](#sources)

---

## Implementation

### Recursive DFS
**Recursive DFS implementation, orchestrator:**
```csharp
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
```
**Recursion logic method:**
```csharp
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
                    bool alreadyRecorded = cycles.Any(
                        edge => edge == (neighbor, current)
                        || edge == (current, neighbor));
                    
                    if (!alreadyRecorded)
                    {
                        cycles.Add((neighbor, current));
                    }
                }
            }
        }
```


### Iterative DFS

### Extension
**Chose extension:** Cycle Detection

---

## Tests

---

## Comparison

---

## Sources