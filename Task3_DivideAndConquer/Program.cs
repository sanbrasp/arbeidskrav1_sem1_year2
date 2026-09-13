using Spectre.Console;
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
        
        AnsiConsole.MarkupLine("[green bold]Demonstration of MergeSort algorithm:[/]");
        
        Console.WriteLine();
        
        // Array before MergeSort:
        AnsiConsole.MarkupLine($"[green bold]First task specified array:[/]");
        AnsiConsole.MarkupLine("[green bold]Task specified array before sort:[/]");
        AnsiConsole.MarkupLine($"[grey]{string.Join(", ", taskSpecifiedArray)}[/]");
        
        // MergeSort call:
        Sort.ResetAndRunMergeSort(taskSpecifiedArray);
        AnsiConsole.MarkupLine($"[green bold]Task specified array after sort:[/]");
        AnsiConsole.MarkupLine($"[grey]{string.Join(", ", taskSpecifiedArray)}[/]");
        AnsiConsole.MarkupLine($"[blue]Comparison count: {Sort.ComparisonCounter}[/]");
        AnsiConsole.MarkupLine($"[blue]Merge call count: {Sort.MergeCallCounter}[/]");
        
        Console.WriteLine();
        
        // Array before MergeSort:
        AnsiConsole.MarkupLine($"[green bold]Task specified sorted array:[/]");
        AnsiConsole.MarkupLine("[green bold]Task specified sorted array before sort:[/]");
        AnsiConsole.MarkupLine($"[grey]{string.Join(", ", sortedArray)}[/]");
        
        // MergeSort call:
        Sort.ResetAndRunMergeSort(sortedArray);
        AnsiConsole.MarkupLine($"[green bold]Task specified sorted array after sort:[/]");
        AnsiConsole.MarkupLine($"[grey]{string.Join(", ", sortedArray)}[/]");
        AnsiConsole.MarkupLine($"[blue]Comparison count: {Sort.ComparisonCounter}[/]");
        AnsiConsole.MarkupLine($"[blue]Merge call count: {Sort.MergeCallCounter}[/]");
        
        Console.WriteLine();
        
        // Array before MergeSort:
        AnsiConsole.MarkupLine($"[green bold]Task specified reverse sorted array:[/]");
        AnsiConsole.MarkupLine("[green bold]Task specified reverse array before sort:[/]");
        AnsiConsole.MarkupLine($"[grey]{string.Join(", ", reverseSortedArray)}[/]");
        
        // MergeSort call:
        Sort.ResetAndRunMergeSort(reverseSortedArray);
        AnsiConsole.MarkupLine($"[green bold]Task specified reverse array after sort:[/]");
        AnsiConsole.MarkupLine($"[grey]{string.Join(", ", reverseSortedArray)}[/]");
        AnsiConsole.MarkupLine($"[blue]Comparison count: {Sort.ComparisonCounter}[/]");
        AnsiConsole.MarkupLine($"[blue]Merge call count: {Sort.MergeCallCounter}[/]");
        
        Console.WriteLine();
        
        // Array before MergeSort:
        AnsiConsole.MarkupLine($"[green bold]Duplicate value array:[/]");
        AnsiConsole.MarkupLine("[green bold]Duplicate value array before sort:[/]");
        AnsiConsole.MarkupLine($"[grey]{string.Join(", ", arrayWithDuplicates)}[/]");
        
        // MergeSort call:
        Sort.ResetAndRunMergeSort(arrayWithDuplicates);
        AnsiConsole.MarkupLine($"[green bold]Duplicate value array after sort:[/]");
        AnsiConsole.MarkupLine($"[grey]{string.Join(", ", arrayWithDuplicates)}[/]");
        AnsiConsole.MarkupLine($"[blue]Comparison count: {Sort.ComparisonCounter}[/]");
        AnsiConsole.MarkupLine($"[blue]Merge call count: {Sort.MergeCallCounter}[/]");
        
        Console.WriteLine();
        
        // Array before MergeSort:
        AnsiConsole.MarkupLine($"[green bold]Empty array:[/]");
        AnsiConsole.MarkupLine("[green bold]Empty array before sort:[/]");
        AnsiConsole.MarkupLine($"[grey]{string.Join(", ", emptyArray)} (empty)[/]");
        
        // MergeSort call:
        Sort.ResetAndRunMergeSort(emptyArray);
        AnsiConsole.MarkupLine($"[green bold]Empty array after sort:[/]");
        AnsiConsole.MarkupLine($"[grey]{string.Join(", ", emptyArray)} (still empty)[/]");
        AnsiConsole.MarkupLine($"[blue]Comparison count: {Sort.ComparisonCounter}[/]");
        AnsiConsole.MarkupLine($"[blue]Merge call count: {Sort.MergeCallCounter}[/]");
        
        Console.WriteLine();
        
        // Array before MergeSort:
        AnsiConsole.MarkupLine($"[green bold]Single-value array:[/]");
        AnsiConsole.MarkupLine("[green bold]Single-value array before sort:[/]");
        AnsiConsole.MarkupLine($"[grey]{string.Join(", ", singleValueArray)}[/]");
        
        // MergeSort call:
        Sort.ResetAndRunMergeSort(singleValueArray);
        AnsiConsole.MarkupLine($"[green bold]Single-value array after sort:[/]");
        AnsiConsole.MarkupLine($"[grey]{string.Join(", ", singleValueArray)}[/]");
        AnsiConsole.MarkupLine($"[blue]Comparison count: {Sort.ComparisonCounter}[/]");
        AnsiConsole.MarkupLine($"[blue]Merge call count: {Sort.MergeCallCounter}[/]");
    }
}