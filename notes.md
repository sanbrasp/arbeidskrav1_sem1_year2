# Task 1 Decision Notes

## LinearSearch():

The class that contains `LinearSearch()`:  
[Search.LinearSearch(int[] array, int target)](Task1_LinearSearchAndBinarySearch/Models/Search.cs)  

**Naming Choice**  
The name `Search` was chosen for the file, as opposed to `LinearSearch`, to avoid ambiguous naming.  
The method name is `LinearSearch`, so the call would be `Search.LinearSearch(array, target);`  
I later decided to group both `LinearSearch()` and `BinarySearch()` in the same class due to being similar
in nature (regardless of differences in how they operate). This follows how many of the built-in methods are set up 
as well (similar use case, same class).

**Loop Decision**  
I decided to use a `for loop` in my Linear Search, because the for loop hands me the index "for free".  

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
unneccessary risk - forgetting to manually reset the counter would produce the wrong result, and nothing outside 
of the class should bear that responsibility; not the developer, not Program.cs.  
I instead wrote `LinearSearch` to call `ResetComparisons` at the very start of the method, ensuring the counter 
always starts with a state of 0. The method `ResetComparisons` was then set to its appropriate access modifier: `private`.

---

## BinarySearch():
The class that contains method `BinarySearch()`:  
[Search.BinarySearch(int[] array, int target)](Task1_LinearSearchAndBinarySearch/Models/Search.cs)

**Naming Choice**  
Refer to the same paragraph of `LinearSearch()`.  

**Loop Decision**  
As is standard for loops where you do not know exactly how many iterations you will need, I decided 
to use the while loop for this algorithm. It runs on the condition set being true, and keeps going until the 
condition is no longer true (`while (left <= right)` => keep iterating).

**Comparison Counter**  
`BinarySearch` has its own `binarySearchComparisons` counter to keep track of the number of comparisons made.  

**What Is It Counting**  
While `LinearSearch` only asks once per element, `BinarySearch` has two different points of comparison questions.  
`is mid == target?` and the directional one `is mid < target?`. Both of these are counted on purpose.

**Encapsulation**  
As with `LinearSearch`, the same encapsulation convention is used for `BinarySearch`. The method is `internal` 
and the backing field for the counter is `private` with an internal getter for displaying value, and a `private` 
helper for resetting the counter from within the class (called from the start of `BinarySearch`).

---