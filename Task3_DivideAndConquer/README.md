# Task 3 - Divide And Conquer

DELETE THIS WHEN DONE!
- ✅ Choose ~~QuickSort~~ or `MergeSort`
- ✅ Implement core recursive method with exact required signature of your choice
- Implement required helper method (~~Partition for Q~~ and `Merge` for `MergeSort`)
- Design your operation counters  (comparisons for both, + algorithm specific extra: ~~swaps for Q~~ or 
  `merge-calls/element-copies` for `MergeSort`, decide exactly what counts as each (like in task 1))
- ~~For QuickSort: choose one pivot strategy deliberately and be ready to explain how that choice affects splitting/performance)~~
- _For MergeSort: think through your temporary storage approach and how it affects space complexity_
- Confirm and be able to explain recursion termination: what is your base case, and why does the recursion guarantee to reach it?
- Test all five required data sets, printing/documenting before-and-after state for each
- Write analysis: base case explanation, recursive splitting explanation, ho sub-results combine into a sorted whole, 
  time complexity (best, avg, worst), space complexity, and a reflection on strengths/weaknesses/input-data sensitivity
- ✅ Algorithm code and tests separate (already the case)

---

_MergeSort it is!_

---

## Overview
- [Implementation](#implementation)
- [Tests](#tests)
- [Operation Count](#operation-count)
- [Analysis](#analysis)
- [Sources](#sources)

---

## Implementation
While I like both `QuickSort` and `MergeSort`, I eventually landed on `MergeSort` for this task, simply because I 
think it is such an interesting and thorough algorithm, and because it guarantees `O(n log n)` time complexity every time - 
`best / avg / worst`. It also carries some fundamental similarities to `BinarySearch` in the way it processes arrays, 
which I also find fascinating.

---

## Tests

---

## Operation Count

---

## Analysis

---

### Sources
- [@Michael Sambol - YouTube - Merge sort in 3 minutes](https://www.youtube.com/watch?v=4VqmGXwpLqc)  
Screenshot from video - step by step splitting, then merge/sort:  ![img.png](Images/img.png)  
- [@Bro Code - YouTube - Learn Merge Sort in 13 minutes](https://www.youtube.com/watch?v=3j0SWDX4AtU)  
Screenshot from video - step by step splitting, then merge/sort: ![img.png](Images/img1.png)
Screenshot from video - Time and Space Complexity: ![img.png](Images/img3.png)
- [@Bálint Benedek Tóth - YouTube - Merge Sort Algorithm in C#](https://www.youtube.com/watch?v=8mZhUH3JsR8)  
