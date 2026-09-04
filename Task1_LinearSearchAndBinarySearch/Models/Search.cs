namespace Task1_LinearSearchAndBinarySearch.Models;

/// <summary>
/// A collection of search algorithms for Linear Search and Binary Search.
/// </summary>
internal static class Search
{
    private static int _comparisons = 0;
    /// <summary>
    /// Getter for displaying the number of comparisons made after a search has completed.
    /// </summary>
    internal static int Comparisons => _comparisons;
    
    /// <summary>
    /// Runs a linear search for a target in an array.
    /// </summary>
    /// <param name="array">Name of array to search.</param>
    /// <param name="target">The target element to search for.</param>
    /// <returns></returns>
    internal static int LinearSearch(int[] array, int target)
    {
        ResetComparisons();
        for (int i = 0; i < array.Length; i++)
        {
            _comparisons++;
            if (array[i] == target)
            {
                return i;
            }
        }
        return -1;
    }
    
    private static void ResetComparisons()
    {
        _comparisons = 0;
    }
}