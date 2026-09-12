namespace Task3_DivideAndConquer.Models;

internal class Sort
{
    /// <summary>
    /// Runs a merge sort on an array of integers.
    /// </summary>
    /// <param name="array">The input array.</param>
    /// <param name="left">Marks the start of the section we are looking at.</param>
    /// <param name="right">Marks the end of the section we are looking at.</param>
    internal static void MergeSort(int[] array, int left, int right)
    {
        if (left >= right) // base case
        {
            // Nothing to do here, stop everything once this condition is true.
            return;
        }
        int mid = left + (right - left) / 2;
        MergeSort(array, left, mid); // left half starts at left and ends at mid
        MergeSort(array, mid + 1, right); // right half starts at mid + 1 and ends at right
        Merge(array, left, mid, right);
    }
    
    /// <summary>
    /// Helper method for the MergeSort method.
    /// </summary>
    /// <param name="array">The array to perform the merge on.</param>
    /// <param name="left">The left sub-array.</param>
    /// <param name="middle">The middle point of the sub-array.</param>
    /// <param name="right">The right sub-array.</param>
    private static void Merge(int[] array, int left, int middle, int right)
    {
        int comparisonCounter = 0;
        int[] leftArray = array[left..(middle +1)]; // define the left side array, starts at left, ends at middle +1 (start inclusive, end exclusive)
        int[] rightArray = array[(middle +1)..(right + 1)]; // define right side array, starts at middle +1, ends at right +1 (start inclusive, end exclusive)

        int l = 0, r = 0, o = left; // Define the starting positions for l, r and o(original)

        while (l < leftArray.Length && r < rightArray.Length)
        {
            if (leftArray[l] < rightArray[r]) // Comparing the front of left to the front of right, if left is smaller
            {
                comparisonCounter++;
                array[o] = leftArray[l++]; // put left into the original array and increment the position for the left pointer in the sub-array
                o++; // increment the position for the original array
            }
            else
            {
                comparisonCounter++;
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
}