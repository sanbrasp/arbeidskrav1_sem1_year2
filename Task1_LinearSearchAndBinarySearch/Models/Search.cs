namespace Task1_LinearSearchAndBinarySearch.Models;

internal static class Search
{
    private static int _comparisons = 0;
    internal static int Comparisons => _comparisons;
    
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