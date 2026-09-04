# Task 1 - Linear and Binary Search


## Overview
- [Implementation](#implementation)
- [Test Results](#test-results)
- [Analysis](#analysis)
- [Task Description](#task-description)

---

## Implementation
The hows and whys.

---

## Test Results
Brief about the test results, add some output screenshots and such.

---

## Analysis
- Big-O explanation for both algorithms
- My definition of "what counts as one comparison".
- My reflection on the unsorted-binary-experiment. Why is it not trustworthy?
- My reflection on when sorting-then-binary-searching is worth the upfront cost vs just linear searching

---

## Task Description

Purpose:  
Implement two search algorithms, count the number of comparisons, and use the results to explain the difference in 
efficiency. Linear Search goes through elements in order. Binary Search halves the search area at each step, but 
requires the data to be sorted.

---

Requirements:  
- Implement `int LinearSearch(int[] array, int target)` that returns the index of the target value, or `-1` if
  the value is not found.
- Implement `int BinarySearch(int[] array, int target)` on an ascending sorted array. Use variables representing 
  lower bound, upper bound, and midpoint.
- `BinarySearch` must return the _first_ occurrence (lowest index) when the target value occurs multiple times.
- Count the number of relevant comparisons in both algorithms, and clearly print that count for each search.
- Explain the time complexity of both algorithms using `Big-O`, including the best and worst case.
- Explain why `BinarySearch` requires sorted data, and reflect on when the cost of sorting first can be justified.

---

Test data and edge cases:
- Run linear search on `[8, 3, 11, 7, 2, 9, 5]`. Search for `7` and `42`.
- Run binary search on `[2, 5, 7, 9, 11, 13, 17]`. Search for `13` and `4`.
- Run binary search on an _unsorted_ **copy** of the dataset, observe the result, and explain 
  why the result isn't reliable. This experiment must not change the contract that the method requires
  sorted input.
- Test an empty array, a single-element array, a target value outside the range, and duplicates. For duplicates,
  the test must show that the first occurrence is returned.

---


