namespace Task1_LinearSearchAndBinarySearch.Models;

/// <summary>
/// A collection of search algorithms for Linear Search and Binary Search.
/// </summary>
internal static class Search
{
    private static int _linearComparisons = 0;
    private static int _binaryComparisons = 0;
    
    /// <summary>
    /// Getter for displaying the number of comparisons made after a linear search has completed.
    /// </summary>
    internal static int LinearComparisons => _linearComparisons;
    /// <summary>
    /// Getter for displaying the number of comparisons after a binary search has completed.
    /// </summary>
    internal static int BinaryComparisons => _binaryComparisons;
    
    
    /// <summary>
    /// Runs a linear search for a target in an array.
    /// </summary>
    /// <param name="array">Name of array to search.</param>
    /// <param name="target">The target element to search for.</param>
    /// <returns></returns>
    internal static int LinearSearch(int[] array, int target)
    {
        ResetLinearComparisons();
        for (int i = 0; i < array.Length; i++)
        {
            _linearComparisons++;
            if (array[i] == target)
            {
                return i;
            }
        }
        return -1;
    }
    
    /// <summary>
    /// Private method belonging to the class <see cref="Search"/>
    /// allowing the class access to reset the <see cref="LinearComparisons"/> counter.
    /// </summary>
    private static void ResetLinearComparisons()
    {
        _linearComparisons = 0;
    }


    /// <summary>
    /// Runs a binary search for a target in a sorted array.
    /// </summary>
    /// <param name="array">The array to search in.</param>
    /// <param name="target">The target to search for.</param>
    /// <returns></returns>
    internal static int BinarySearch(int[] array, int target)
    {
        ResetBinaryComparisons();

        int left = 0;
        int right = array.Length - 1;
        int lowestMatchResult = -1; // initialized with sentinel value.

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            
            _binaryComparisons++;
            if (array[mid] == target)
            {
                lowestMatchResult = mid;
                right = mid - 1;
            }
            
            else if (array[mid] < target)
            {
                _binaryComparisons++;
                left = mid + 1;
            }
                
            else
            {
                right = mid - 1;
            }
        }
        return lowestMatchResult;
    }
    
    /// <summary>
    /// Private method belonging to the class <see cref="Search"/>
    /// allowing the class access to reset the <see cref="BinaryComparisons"/> counter.
    /// </summary>
    private static void ResetBinaryComparisons()
    {
        _binaryComparisons = 0;
    }
}