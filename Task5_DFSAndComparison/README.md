# Task 5 - DFS and Comparison
DFS, and comparison with BFS.

DELETE WHEN FINISHED:   (Mark with ✅ )
Bullet list: 
1. ✅ Reuse the Task 4 graph — same test graph, same edges, same Graph class.
2. ✅ Implement recursive DFS — needs a visited-tracking structure; needs a defined base step and recursive step.
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
    - [DFS-Based Extension Method](#dfs-based-extension-method)
  - [Iterative DFS](#iterative-dfs)
  - [Extension](#extension)
- [Tests](#tests)
- [Comparison](#comparison)
- [Explanation](#explanation)
  - [Base Step](#base-step)
  - [Recursive Step](#recursive-step)
  - [O(V+E)](#ove)
  - [Differences Between Recursive and Iterative DFS](#differences-between-recursive-and-iterative-dfs)
  - [Risk of StackOverFlowException](#risk-of-stackoverflowexception)
- [Sources](#sources)

---

## Implementation

### Recursive DFS
**Recursive DFS implementation, orchestrator:**
```csharp
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
```
- Guards for non-existent startNode.  
- Calls the `Recursion()` logic.  
- Returns the `result` data.

**Recursion logic method:**
```csharp
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
```
Guards against running recursion on already visited nodes.  
Immediately adds `current` to `visited`.  
Immediately thereafter adds `current` to `result`.

It then pulls the needed values from the `adjacencyList` with an `out var neighbors` (List).  
It loops through the `neighbor` elements in `neighbors`, and performs the check `if (!visited.Contains(neighbor))`:
⇒ if true ⇒ run `Recursion()`.

### Recursive DFS Extension Method
Cycle Discovery.  
Based on basic DFS with recursion.
```csharp
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
```

**Recursion For Cycles:**
```csharp
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
```
- Based on the recursion method that `RecursiveDfs()` uses. 
- Also keeps track of `previous` in order to check neighbors against that and `visited` in order to find cycles. 
- _If a neighbor is in `visited` but is **NOT** the one we stepped off of (`previous`), we have a cycle._
- Avoids duplicate results in recorded cycles using `bool alreadyRecorded`, which ensures only one occurrence of two neighbors 
  is recorded (because of the two-way direction, a duplicate would be recorded without it).


### Iterative DFS
```csharp
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
```
- Guards against missing startnode
- Uses an explicit `Stack<string>`
- Pushes elements to the stack
- Pops the element that was "last in" (LIFO)
- Marks nodes as visited immediately upon discovery
- Returns a list of visited nodes in order
- Loop results and Pushes reversed to mirror results from `RecursiveDfs()`

### Iterative DFS Extension Method
Finds a route if one exists, returning true or false:
```csharp
internal static bool FindRoute(Dictionary<string, List<string>> adjacencyList, string startNode, string targetNode)
    {
        if (!adjacencyList.ContainsKey(startNode) || (!adjacencyList.ContainsKey(targetNode)))
        {
            return false;
        }

        HashSet<string> visited = new();
        Stack<string> stack = new();
        
        stack.Push(startNode);
        visited.Add(startNode);

        while (stack.Count > 0)
        {
            string current = stack.Pop();
            
            if (current == targetNode)
            {
                return true;
            }
            else if (adjacencyList.TryGetValue(current, out var neighbors))
            {
                foreach (var neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        stack.Push(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }
        }
        return false;
    }
```
- Based on `IterativeDfs()`, but is a `bool` return type
- Guards against missing start node and target node
- Checks the first Popped element to see if `current == target` 
- If True, returns `True`
- If False, the `else if` branch fires and starts looking through neighbors, the same way 
  the original `IterativeDfs()` does, until the condition `current == target` becomes true. 
- If neither `if` or `else if` conditions become true, it returns `false`.

---


## Tests
**Tests run successfully:**
![success](Images/successfulltests.png)

**Test names**  

- `DetectCycles_DetectsCycles_WhereThereAreCycles`
- `DetectCycles_DoesNotDetectCycles_WhereThereAreNoCycles`
- `FindRoute_ReturnsFalse_OnNoRouteAndMissingStartAndTarget`
- `FindRoute_ReturnsFalse_OnNoRouteAndMissingStartAndTarget(start: "Majorstuen", end: "Leirfjord")`
- `FindRoute_ReturnsFalse_OnNoRouteAndMissingStartAndTarget(start: "Månen", end: "Jernbanetorget")`
- `FindRoute_ReturnsFalse_OnNoRouteAndMissingStartAndTarget(start: "Nationaltheatret", end: "Merkur")`
- `FindRoute_ReturnsFalse_OnNoRouteAndMissingStartAndTarget(start: "Sola", end: "Månen")`
- `FindRoute_ReturnsTrue_OnExistingRoute`
- `FindRoute_ReturnsTrue_OnExistingRoute(start: "Majorstuen", end: "Forskningsparken")`
- `FindRoute_ReturnsTrue_OnExistingRoute(start: "Tøyen", end: "Stortinget")`
- `IterativeDfs_HandlesMissingStartNode`
- `IterativeDfs_ReturnsCorrectVisitOrder_FromMajorstuen`
- `IterativeDfsAndRecursiveDfs_ReturnIdenticalVisitOrder`
- `RecursiveDfs_DoesNotReachIsolatedStationLeirfjord_FromAnywhere`
- `RecursiveDfs_DoesNotReachIsolatedStationLeirfjord_FromAnywhere(startNode: "Majorstuen")`
- `RecursiveDfs_DoesNotReachIsolatedStationLeirfjord_FromAnywhere(startNode: "Tøyen")`
- `RecursiveDfs_HandlesMissingStartNode`
- `RecursiveDfs_ReturnsCorrectVisitOrder_FromMajorstuen`

**Test Cases**
- `RecursiveDfs()` visit order from `Majorstuen`
- `RecursiveDfs()` missing node handling
- `RecursiveDfs()` isolated node handling
- `DetectCycles()` does not record cycles where there are none
- `DetectCycles()` detects cycles where there are any, and does not return a duplicate result
- `IterativeDfs()` same visit order as `RecursiveDfs()` that match exactly
- `IterativeDfs()` missing start node handling
- `FindRoute()` reaches the target and returns true when there is a path between two
- `FindRoute()` returns false when trying to reach isolated station
- `FindRoute()` returns false whenever start, target, or both are missing

**Why This is Tested**  
To ensure a mirrored result between `RecursiveDfs()` and `IterativeDfs()`.  
To ensure the code works as intended.  
To ensure the code can handle edge-cases without crashing.

---

## Comparison

---

## Explanation
### Base Step

### Recursive Step

### Extension
**Chosen extension for Recursive DFS:** Cycle Detection

**Chosen extension for Iterative DFS:** Route between two stations

### O(V+E)

### Differences Between Recursive and Iterative DFS

### Risk of StackOverFlowException

---

## Sources