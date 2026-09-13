using System.Net;
using Task3_DivideAndConquer.Models;

namespace Task3_DivideAndConquer;

class Program
{
    static void Main(string[] args)
    {
        int[] taskSpecifiedArray = [64, 34, 25, 12, 22, 11, 90];
        int[] sortedArray = [1, 2, 3, 4, 5];
        int[] reverseSortedArray = [9, 8, 7, 6, 5];
        int[] arrayWithDuplicates = [2, 22, 67, 7, 12, 27, 17, 2];
        int[] emptyArray = [];
        int[] singleValueArray = [1024];
        
        Sort.ResetAndRunMergeSort(emptyArray);
        foreach (var element in emptyArray)
        {
            Console.WriteLine(element);
        }
        Console.WriteLine($"Comparison count: {Sort.ComparisonCounter}");
        Console.WriteLine($"Merge call count: {Sort.MergeCallCounter}");
    }
}