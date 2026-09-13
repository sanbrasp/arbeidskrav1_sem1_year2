# Task 3 - Divide And Conquer

DELETE THIS WHEN DONE!
- ✅ Choose: `MergeSort`
- ✅ Implement core recursive method with exact required signature of your choice
- ✅ Implement required helper method: `Merge` for `MergeSort`)
- Design your operation counters  (comparisons for both, + algorithm specific extra: 
  `merge-calls/element-copies` for `MergeSort`, decide exactly what counts as each (like in task 1))
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

`void ResetAndRunMergeSort(int[] array)]`:  
```csharp
internal static void ResetAndRunMergeSort(int[] array)
    {
        ResetComparisonCounter();
        ResetMergeCallCounter();
        
        MergeSort(array, 0, array.Length - 1);
    }
```
A very plain orchestrator to ensure the correct order of steps:  
- Reset first, only once per counter
- Run the `MergeSort()` algorithm
- Ensure correct counter data between runs

`void MergeSort(int[] array, int left, int right)`:  
```csharp
private static void MergeSort(int[] array, int left, int right)
    {
        if (left >= right) // base case
        {
            // Nothing to do here, stop everything once this condition is true.
            return;
        }
        int mid = left + (right - left) / 2;
        MergeSort(array, left, mid); // left half starts at left and ends at mid
        MergeSort(array, mid + 1, right); // right half starts at mid + 1 and ends at right
        _mergeCallCounter++;
        Merge(array, left, mid, right);
    }
```
TODO: Write about method here!

`void Merge(int[] array, int left, int middle, int right)`:  
```csharp
private static void Merge(int[] array, int left, int middle, int right)
    {
        int[] leftArray = array[left..(middle +1)]; // define the left side array, starts at left, ends at middle +1 (start inclusive, end exclusive)
        int[] rightArray = array[(middle +1)..(right + 1)]; // define right side array, starts at middle +1, ends at right +1 (start inclusive, end exclusive)

        int l = 0, r = 0, o = left; // Define the starting positions for l, r and o(original)

        while (l < leftArray.Length && r < rightArray.Length)
        {
            _comparisonCounter++;
            if (leftArray[l] < rightArray[r]) // Comparing the front of left to the front of right, if left is smaller
            {
                array[o] = leftArray[l++]; // put left into the original array and increment the position for the left pointer in the sub-array
                o++; // increment the position for the original array
            }
            else
            {
                array[o] = rightArray[r++]; // if right is smaller than left, put it into the original array, increment right position pointer
                o++; // increment the position for the original array
            }
        }
        // Check for remaining elements in each block (left and right)
        while (l < leftArray.Length)
        {
            array[o] = leftArray[l++]; // same logic as the main comparison branches, but no comparisons
            o++;
        }

        while (r < rightArray.Length)
        {
            array[o] = rightArray[r++];
            o++;
        }
    }
```
TODO: Write about method here!

Helper methods: `void ResetComparisonCounter()` and `void ResetMergeCallCounter()` are very simple and do just that, nothing more.

<br>

**Choices**  
`MergeSort()` set to `private`.  
While adding the counters to the `Sort` class, I ended up writing a wrapper method that would safely 
handle the resetting of the counters to avoid corrupted results that resetting inside the `MergeSort()` method would lead to. 
To do this safely, I added those resets to the top of the wrapper method (`ResetAndRunMergeSort(int[] array)`).  
The counters are now reset only once, and _then_ the `MergeSort()` is performed, ensuring valid counter results.   
Due to this I decided that `MergeSort()` should be `private` as there was no longer any need for it to be called 
directly from outside the class `Sort` itself. No needless exposure.  

The test suite will also use the wrapper method to ensure non-corrupted counters, while still achieving 
the correct behavior from the `MergeSort()` method. 

`Merge()`, `ResetComparisonCounter()`, and `ResetMergeCallCounter` are also set to `private` because they are only run 
from within the class itself and do not need to be exposed outside of it.  

---

## Tests
Add screenshots, names, test cases, why it's being tested, here.

Added bonus: A hand-trace of the full `MergeSort()` and `Merge()` process, counting comparisons and merge calls manually:
![hand trace](Images/HandTraceOfMergeSort.png)  
Excuse the chaos and typos, but I spent too much time doing this for it just to remain unseen by anyone else than me.

---

## Operation Count
**What is Counted**  
`Comparisons` and `Merge()` calls.

---

## Analysis
**Temporary Storage:**  
`leftArray`  
`rightArray`

**Time and Space Complexity:**  

**Trade-Offs**  

**Bug Fixing**  
**`MergeSort()`** - start and end boundaries were off, neither recursive call included `mid`.     
I had set the left call's range to `left` through `mid -1`, and the right call's range from `mid+1` through `right`, 
skipping `mid` entirely on both sides.  
The rule I intended to operate by was `mid belongs to left`, so the left call needed to end at `mid` itself.  
I had also been mixing up "indice slicing" and `start/stop` ranges.
This led to bugs itself, and also trailed into the `Merge()` method.
With the right questions from `Claude.ai` (documented in [AIUse.md](../Docs/AIUse.md)), 
I was able to step my way through what I had done wrong and correct it.  
However, the next couple of bugs still remained:

**`Merge()`** - the array slices were off by one, for the same underlying reason: `middle` was not included where it needed to be.    
I had again mixed up two different systems: `MergeSort()`'s parameters that are plain numbers, and `Merge()`'s array slices that 
use C#'s `exclusive-end range` syntax, requiring the `+1` adjustment to include the boundary.  
I made the wrong slices for both `leftArray` and `rightArray` several times before getting it right, 
and due to the previous bug, even when the arrays were correctly sliced, it produced bugs.  
`leftArray` did not include `middle` for quite some time, and the confusion from the bug above also 
translated into this, where I got "slicing range" and "start and end range" mixed up.  
`Claude.ai` walked me through this by asking the right questions and making me think my way to the answer, 
and I realized one couldn't have worked without the other (MergeSort and Merge) due to both of them containing 
bugs that would break the other even if one had the correct logic. They followed different rules (`mid belongs to left`),
and didn't speak the same language.  
By walking through my own set rule, ensuring the `start` and `end` ranges in `MergeSort` were correct, 
and tracing through my indices setup, I was able to gather the error:  
the left ended at the wrong boundary,   
and the right ended at the wrong boundary. 

Fixes were applied to both methods and tested on several different arrays to ensure everything was in order.

---

### Sources
- [@Michael Sambol - YouTube - Merge sort in 3 minutes](https://www.youtube.com/watch?v=4VqmGXwpLqc)  
Screenshot from video - step by step splitting, then merge/sort:  ![img.png](Images/img.png)  
- [@Bro Code - YouTube - Learn Merge Sort in 13 minutes](https://www.youtube.com/watch?v=3j0SWDX4AtU)  
Screenshot from video - step by step splitting, then merge/sort: ![img.png](Images/img1.png)
Screenshot from video - Time and Space Complexity: ![img.png](Images/img3.png)
- [@Bálint Benedek Tóth - YouTube - Merge Sort Algorithm in C#](https://www.youtube.com/watch?v=8mZhUH3JsR8)  
