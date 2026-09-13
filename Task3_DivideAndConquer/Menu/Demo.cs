using Spectre.Console;
using Task3_DivideAndConquer.Models;

namespace Task3_DivideAndConquer.Menu;

internal class Demo
{
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