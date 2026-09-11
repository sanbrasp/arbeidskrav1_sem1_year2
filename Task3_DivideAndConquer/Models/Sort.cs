namespace Task3_DivideAndConquer.Models;

internal class Sort
{
    /// <summary>
    /// Runs a merge sort on an array of integers.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    internal void MergeSort(int[] array, int left, int right)
    {
        if (left >= right) // base case
        {
            // Nothing to do here, stop everything once this condition is true.
            return;
        }
        int mid = left + (right - left) / 2;
        MergeSort(array, left, mid - 1); // left half starts at left and ends at mid - 1
        MergeSort(array, mid + 1, right); // right half starts at mid + 1 and ends at right
    }
    
    /// <summary>
    /// Helper method for the MergeSort method.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="left"></param>
    /// <param name="middle"></param>
    /// <param name="right"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void Merge(int[] array, int left, int middle, int right)
    {
        int tempStorageSize = right - left + 1;
        int[] leftArray = array[left..(middle)]; // define the left side array, starts at left, ends at middle -1 (start inclusive, end exclusive)
        int[] rightArray = array[(middle + 1)..(right + 1)]; // define right side array, starts at middle +1, ends at right (start inclusive, end exclusive)

        int l = 0, r = 0, t = 0;
        
    }
}