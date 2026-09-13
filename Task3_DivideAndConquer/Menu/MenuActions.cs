using System.Reflection.Metadata.Ecma335;
using Task3_DivideAndConquer.Helpers;

namespace Task3_DivideAndConquer.Menu;

/// <summary>
/// A class that controls user input to domain logic.
/// </summary>
internal static class MenuActions
{
    internal static void FirstArray()
    {
        int[] taskSpecifiedArray = [64, 34, 25, 12, 22, 11, 90];
        Console.Clear();
        Demo.RunDemo("First Task Specified Array", taskSpecifiedArray);
        
        FlowHelpers.Pause();
    }

    internal static void SortedArray()
    {
        int[] sortedArray = [1, 2, 3, 4, 5];
        Console.Clear();
        Demo.RunDemo("Sorted Array", sortedArray);
        
        FlowHelpers.Pause();
    }

    internal static void ReverseSortedArray()
    {
        int[] reverseSortedArray = [9, 8, 7, 6, 5];
        Console.Clear();
        Demo.RunDemo("Reverse Sorted Array", reverseSortedArray);
        
        FlowHelpers.Pause();
    }

    internal static void ArrayWithDuplicateValues()
    {
        int[] arrayWithDuplicates = [2, 22, 67, 7, 12, 27, 17, 2];
        Console.Clear();
        Demo.RunDemo("Array With Duplicate Values", arrayWithDuplicates);
        
        FlowHelpers.Pause();
    }
    
    internal static void EmptyArray()
    {
        int[] emptyArray = [];
        Console.Clear();
        Demo.RunDemo("Empty Array", emptyArray);
        
        FlowHelpers.Pause();
    }

    internal static void SingleValueArray()
    {
        int[] singleValueArray = [1024];
        Console.Clear();
        Demo.RunDemo("Single Value Array", singleValueArray);
        
        FlowHelpers.Pause();
    }
}