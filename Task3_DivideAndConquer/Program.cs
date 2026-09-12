using System.Net;
using Task3_DivideAndConquer.Models;

namespace Task3_DivideAndConquer;

class Program
{
    static void Main(string[] args)
    {
        int[] sortedArray = [1, 2, 3, 4, 5];
        int[] reverseSortedArray = [9, 8, 7, 6, 5];
        int[] arrayWithDuplicated = [2, 22, 67, 7, 12, 27, 17, 2];
        int[] emptyArray = [];
        int[] singleValueArray = [1024];
        int[] test = [2, 1];
        
        Sort.ResetAndRunMergeSort(sortedArray);
        foreach (var element in sortedArray)
        {
            Console.WriteLine(element);
        }
        Console.WriteLine($"Comparison count: {Sort.ComparisonCounter}");
        Console.WriteLine($"Merge call count: {Sort.MergeCallCounter}");
    }
}