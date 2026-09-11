namespace Task3_DivideAndConquer.Models;

internal class Sort
{
    internal void MergeSort(int[] array, int left, int right)
    {
        if (left >= right) // base case
        {
            // STAHP!
        }
        else
        {
            int mid = left + (right - left) / 2;
            MergeSort(array, left, mid - 1); // left half starts at left and ends at mid - 1
            MergeSort(array, mid + 1, right); // right half starts at mid + 1 and ends at right
        }
    }
    
    private void Merge(int[] array, int left, int middle, int right)
    {
        throw new NotImplementedException();
    }
}