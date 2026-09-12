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
Add screenshots, names, test cases, why it's being tested, here.

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
`MergeSort()` start and end definition was off (neither side included middle).  
I had initially not set either side (`left` or `right`) to actually include the mid during the calls.  
This led to bugs itself, and also trailed into the `Merge()` method.  
The rule I intended to operate by was `mid belongs to left`, however I had set the starting point for the left side 
to `left` and the ending point to `mid +1`, skipping the middle entirely.  
For the right I had done something similar, setting the start to `mid +1`, skipping mid, and also set 
the end to `right -1` and `right +1` (in different steps during my bug hunt). Both skipping mid, 
and the end for right being entirely wrong because I got the `exclusive-end` behavior from slicing mixed up 
with this step. With the right questions from `Claude.ai` (documented in [AIUse.md](../Docs/AIUse.md)), 
I was able to step my way through what I had done wrong and correct it.  
However, the next couple of bugs still remained:

`Merge()` indice slices were off by one, `mid` became an issue because it wasn't included in the above.  
I had made the wrong slices for both `leftArray` and `rightArray` several times before getting it right, 
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
