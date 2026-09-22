using Spectre.Console;
using Task1_LinearSearchAndBinarySearch.Display;
using Task1_LinearSearchAndBinarySearch.Models;

namespace Task1_LinearSearchAndBinarySearch;

class Program
{
    static void Main(string[] args)
    {
        int[] linearSearchArray = [8, 3, 11, 7, 2, 9, 5];
        int[] binarySearchArray = [2, 5, 7, 9, 11, 13, 17];
        int[] linearDuplicateValuesArray = [8, 3, 11, 7, 2, 9, 5, 2];
        int[] binaryDuplicateValuesArray = [2, 5, 5, 7, 9, 9, 11, 13, 17, 20, 24, 27, 31, 36, 38];
        int[] unluckyBinaryArray = { 25, 3, 19, 7, 12 };
        int[] luckyBinaryArray = { 3, 25, 7, 19, 12 };
        
        var requiredSearchesResults = new List<SearchResult>
        {
            new("LinearSearch", 7, Search.LinearSearch(linearSearchArray, 7), Search.LinearComparisons, ArrayIsSorted: false),
            new("LinearSearch", 42, Search.LinearSearch(linearSearchArray, 42), Search.LinearComparisons, ArrayIsSorted: false),
            new("BinarySearch", 13, Search.BinarySearch(binarySearchArray, 13), Search.BinaryComparisons, ArrayIsSorted: true),
            new("BinarySearch", 4, Search.BinarySearch(binarySearchArray, 4), Search.BinaryComparisons, ArrayIsSorted: true),
        };

        var duplicateValuesResults = new List<SearchResult>
        {
            new("LinearSearch", 2, Search.LinearSearch(linearDuplicateValuesArray, 2), Search.LinearComparisons,
                ArrayIsSorted: false),
            new("BinarySearch", 9, Search.BinarySearch(binaryDuplicateValuesArray, 9), Search.BinaryComparisons,
                ArrayIsSorted: true)
        };

        var binarySearchOnUnsortedArrayResults = new List<SearchResult>
        {
            new("BinarySearch", 7, Search.BinarySearch(luckyBinaryArray, 7), Search.BinaryComparisons,
                ArrayIsSorted: false),
            new("BinarySearch", 7, Search.BinarySearch(unluckyBinaryArray, 7), Search.BinaryComparisons,
                ArrayIsSorted: false)
        };

        AnsiConsole.Write(new Panel($"[green bold]Required Target Searches[/]")
            .RoundedBorder());
        DisplayResult.ShowTable(requiredSearchesResults);
        AnsiConsole.MarkupLine("[green]Shows targets, indexes, number of comparisons, " +
                               "and whether the input is sorted or not.[/]");
        
        Console.WriteLine();
        AnsiConsole.Write(new Panel("[green bold]Duplicate Values Searches[/]")
            .RoundedBorder());
        DisplayResult.ShowTable(duplicateValuesResults);
        AnsiConsole.MarkupLine("[green]The README contains a hand trace proving the guarantee " +
                               "of BinarySearch leftmost target returned.\n" +
                               "No such thing needed for LinearSearch because it always looks " +
                               "at the next neighbor first.[/]");
        
        Console.WriteLine();
        AnsiConsole.Write(new Panel("[green bold]Binary Search On Unsorted Array[/]")
            .RoundedBorder());
        DisplayResult.ShowTable(binarySearchOnUnsortedArrayResults);
        AnsiConsole.MarkupLine("[green]The first search succeeds by accident, the second fails.[/]");
    }
}