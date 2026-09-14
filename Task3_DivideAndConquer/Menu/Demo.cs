using Spectre.Console;
using Task3_DivideAndConquer.Models;

namespace Task3_DivideAndConquer.Menu;

/// <summary>
/// Contains a method that is used in the algorithm demonstration of this task.
/// </summary>
internal class Demo
{
    /// <summary>
    /// Collective output information that can be used with
    /// all the task specified arrays, in line with DRY principles.
    /// </summary>
    /// <param name="label">The title of the operation.</param>
    /// <param name="array">The array that the algorithm runs on.</param>
    internal static void RunDemo(string label, int[] array)
    {
        AnsiConsole.MarkupLine($"[green bold]{label}[/]");
        AnsiConsole.MarkupLine($"[green bold]{label} before sort:[/]");
        AnsiConsole.MarkupLine($"[grey]{string.Join(", ", array)}[/]");
        
        // MergeSort call:
        Sort.ResetAndRunMergeSort(array);
        AnsiConsole.MarkupLine($"[green bold]{label} after sort:[/]");
        AnsiConsole.MarkupLine($"[grey]{string.Join(", ", array)}[/]");
        AnsiConsole.MarkupLine($"[blue]Comparison count: {Sort.ComparisonCounter}[/]");
        AnsiConsole.MarkupLine($"[blue]Merge call count: {Sort.MergeCallCounter}[/]");
    
        Console.WriteLine();
    }
}