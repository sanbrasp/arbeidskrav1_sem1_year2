# Task 1 - Linear and Binary Search


## Overview
- [Implementation](#implementation)
  - [LinearSearch](#linearsearch)
  - [BinarySearch](#binarysearch)
- [Test Results](#test-results)
- [Analysis](#analysis)
- [Task Description](#task-description)

---

## Implementation
## LinearSearch():

The class that contains `LinearSearch()`:  
[Search.LinearSearch()](Task1_LinearSearchAndBinarySearch/Models/Search.cs)

**Naming Choice**  
The name `Search` was chosen for the file, as opposed to `LinearSearch`, to avoid ambiguous naming.  
The method name is `LinearSearch()`, so the call would be `Search.LinearSearch(array, target);`  
I later decided to group both `LinearSearch()` and `BinarySearch()` in the same class due to being similar
in nature (regardless of differences in how they operate). This follows how many of the built-in methods are set up
as well (similar use case, same class).

**Loop Decision**  
I decided to use a `for loop` in my Linear Search, because the for loop hands me the index "for free", omitting
the need to initialize a variable for storing the index.

**Comparison Counter**  
I added a `linearSearchComparisons` counter that gives me the exact number of comparisons processed before
finding the target (if found).

**What Is It Counting**  
It counts _every_ occurrence of comparison done to each element.

**Encapsulation**  
I opted to go for internal and private in the class.  
The class itself is internal, with a private backing field for the `_comparisons` counter,
and an internal property getter `Comparisons => _comparisons` for displaying the data.  
I initially opted for a method accessor in order to display the data, but decided this was the cleaner
approach.

**Resetting the Comparison Counter**  
Initially I had a method accessor for resetting the counter. After some thinking, I decided that this was an
unnecessary risk - forgetting to manually reset the counter would produce the wrong result, and nothing outside
of the class should bear that responsibility; not the developer, not Program.cs.  
I instead wrote `LinearSearch()` to call `ResetComparisons()` at the very start of the method, ensuring the counter
always starts with a state of 0. The method `ResetComparisons()` was then set to its appropriate access modifier: `private`.

---

## BinarySearch():
The class that contains method `BinarySearch()`:  
[Search.BinarySearch()](Task1_LinearSearchAndBinarySearch/Models/Search.cs)

**Naming Choice**  
Refer to the same paragraph of `LinearSearch()`.

**Loop Decision**  
As is standard for loops where you do not know exactly how many iterations you will need, I decided
to use the while loop for this algorithm. It runs on the condition set being true, and keeps going until the
condition is no longer true (`while (left <= right)` => keep iterating).

**Comparison Counter**  
`BinarySearch()` has its own `binarySearchComparisons` counter to keep track of the number of comparisons made.

**What It Is Counting**  
While `LinearSearch()` only asks once per element, `BinarySearch()` has three different comparison branches.  
`is mid == target?` is counted during every iteration, and the directional `is mid < target?` is counted if the first
check is false. Directional `is mid > target` runs only if the two first ones are false. All of these are counted on purpose as they
occur in the code execution.
This is because an `else if` chain was used to control the flow of the algorithm.

**Encapsulation**  
As with `LinearSearch()`, the same encapsulation convention is used for `BinarySearch()`. The method is `internal`
and the backing field for the counter is `private` with an internal getter for displaying value, and a `private`
helper for resetting the counter from within the class (called from the start of `BinarySearch()`).

**Guarantee The Leftmost Occurrence**  
In a test array `int[] binarySearchArray = [2, 5, 5, 7, 9, 9, 11, 13, 17, 20, 24, 27, 31, 36, 38];`  
when the target is `9`, hand trace to prove guarantee:

```text
left = 0, right = 14 (array.Length - 1)

Iteration 1:
mid = 0 + (14-0) / 2 = 7 -> array[7] = 13
    Comparison: 13 == 9 ? No. (Counter: 1)
    Comparison: 13 < 9? No. -> else: right = mid - 1 = 6 (Counter: 2)

Iteration 2:
left = 0, right = 6
mid = 0 + (6-0) / 2 = 3 -> array[3] = 7
    Comparison: 7 == 9? No. (Counter: 3)
    Comparison: 7 < 9? Yes. -> left = mid + 1 = 4 (Counter: 4)

Iteration 3:
left = 4, right = 6
mid = 4 + (6-4) / 2 = 5 -> array[5] = 9
    Comparison: 9 == 9? Yes -> store -> right = mid - 1 = 4 (Counter: 5)

Iteration 4:
left = 4, right = 4
mid = 4 + (4-4) / 2 = 4 -> array[4] = 9
    Comparison: 9 == 9? Yes -> store -> right = mid - 1 = 3 (Counter: 6)

left = 4, right = 3 -> left <= right = false -> loop ends

return lowestMatchResult.
```

The algorithm first finds a hit at index 5, which is not the leftmost (lowest) target value 9.  
It then stores that "hit", keeps looking, and eventually finds the actual leftmost target value
9 at index 4.  
It returns the value of the variable that holds the target: `lowestMatchResult`, or the sentinel `-1` if not found.


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


