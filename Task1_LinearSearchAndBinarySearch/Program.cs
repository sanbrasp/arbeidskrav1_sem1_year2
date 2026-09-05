using Task1_LinearSearchAndBinarySearch.Models;

namespace Task1_LinearSearchAndBinarySearch;

class Program
{
    static void Main(string[] args)
    {
        int[] linearSearchArray = [8, 3, 11, 7, 2, 9, 5];
        int[] binarySearchArray = [2, 5, 7, 9, 11, 13, 17];
        int[] duplicateValuesArray = [2, 5, 5, 7, 9, 9, 11, 13, 17, 20, 24, 27, 31, 36, 38];

        Console.WriteLine("Array with duplicate values test (BinarySearch)");
        Console.WriteLine($"BinarySearch index for target '9': {Search.BinarySearch(duplicateValuesArray, 9)}");
        Console.WriteLine($"BinarySearch number of comparisons: {Search.BinaryComparisons}");

        // This part belongs to Linear Search - along with the array:
        Console.WriteLine("\nLINEAR SEARCH!");
        Console.WriteLine($"Array elements for this task: {string.Join(", ", linearSearchArray)}");
        Console.WriteLine($"\nSearching for target: 7");
        Console.WriteLine($"Target index: {Search.LinearSearch(linearSearchArray, 7)}");
        Console.WriteLine($"Number of comparisons: {Search.LinearComparisons}");
        Console.WriteLine("\nSearching for target: 42");
        Console.WriteLine($"Target index: {Search.LinearSearch(linearSearchArray, 42)}");
        Console.WriteLine($"Number of comparisons: {Search.LinearComparisons}");
        
        // This part belongs to Binary Search - along with the array:
        Console.WriteLine("\nBINARY SEARCH!");
        Console.WriteLine($"Array elements for this task: {string.Join(", ", binarySearchArray)}");
        Console.WriteLine($"\nSearching for target: 13");
        Console.WriteLine($"Target index: {Search.BinarySearch(binarySearchArray, 13)}");
        Console.WriteLine($"Number of comparisons: {Search.BinaryComparisons}");
        Console.WriteLine("\nSearching for target: 4");
        Console.WriteLine($"Target index: {Search.BinarySearch(binarySearchArray, 4)}");
        Console.WriteLine($"Number of comparisons: {Search.BinaryComparisons}");
    }
}