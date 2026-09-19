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


---

## Overview
- [Implementation](#implementation)
  - [Iterative DFS](#iterative-dfs)
  - [Recursive DFS](#recursive-dfs)
  - [Extension](#extension)
- [Tests](#tests)
- [Comparison](#comparison)
- [Sources](#sources)

---

## Implementation

### Iterative DFS

### Recursive DFS

### Extension

---

## Tests

---

## Comparison

---

## Sources