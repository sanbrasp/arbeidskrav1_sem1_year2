# Task 1 Decision Notes

## LinearSearch():

The class that contains `LinearSearch()`:  
[Search.LinearSearch(int[] array, int target)](Task1_LinearSearchAndBinarySearch/Models/Search.cs)  

**Naming Choice**  
The name `Search` was chosen for the file, as opposed to `LinearSearch`, to avoid ambiguous naming.  
The method name is `LinearSearch`, so the call would be `Search.LinearSearch(array, target);`

**Loop Decision**  
I decided to use a `for loop` in my Linear Search, because the for loop hands me the index "for free".  

**Comparison Counter**  
I added a `comparisons` counter that gives me the exact number of comparisons processed before 
finding the target (if found).

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

