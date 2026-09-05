using Task1_LinearSearchAndBinarySearch.Models;

namespace Task1_LinearSearchAndBinarySearch;

class Program
{
    static void Main(string[] args)
    {
        int[] array = [8, 3, 11, 7, 2, 9, 5];

        Console.WriteLine($"Array elements for this task: {string.Join(", ", array)}");

        Console.WriteLine($"\nSearching for target: 7");
        Console.WriteLine($"Target index: {Search.LinearSearch(array, 7)}");
        Console.WriteLine($"Number of comparisons: {Search.Comparisons}");

        Console.WriteLine("\nSearching for target: 42");
        Console.WriteLine($"Target index: {Search.LinearSearch(array, 42)}");
        Console.WriteLine($"Number of comparisons: {Search.Comparisons}");
    }
}