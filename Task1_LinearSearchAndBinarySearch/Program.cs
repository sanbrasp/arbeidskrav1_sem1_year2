using Task1_LinearSearchAndBinarySearch.Models;

namespace Task1_LinearSearchAndBinarySearch;

class Program
{
    static void Main(string[] args)
    {
        int[] array = [8, 3, 11, 7, 2, 9, 5];

        Console.WriteLine(Search.LinearSearch(array, 7));
        Console.WriteLine(Search.GetComparisons());
        Search.ResetComparisons();
        Console.WriteLine(Search.LinearSearch(array, 42));
        Console.WriteLine(Search.GetComparisons());
    }
}