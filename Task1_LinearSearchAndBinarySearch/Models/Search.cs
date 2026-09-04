namespace Task1_LinearSearchAndBinarySearch.Models;

internal static class Search
{
    private static int _comparisons = 0;
    
    internal static int LinearSearch(int[] array, int target)
    {
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

    internal static int GetComparisons()
    {
        return _comparisons;
    }

    internal static void ResetComparisons()
    {
        _comparisons = 0;
    }
}