using Spectre.Console;
using Task3_DivideAndConquer.Menu;
using Task3_DivideAndConquer.Models;

namespace Task3_DivideAndConquer;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            AnsiConsole.MarkupLine("[green bold]=== Demonstration of MergeSort algorithm ===[/]");
            AnsiConsole.MarkupLine("[green]Choose option:[/]");
            AnsiConsole.MarkupLine("[blue]1. First Specified Array.[/]");
            AnsiConsole.MarkupLine("[blue]2. Sorted Array.[/]");
            AnsiConsole.MarkupLine("[blue]3. Reverse Sorted Array.[/]");
            AnsiConsole.MarkupLine("[blue]4. Duplicate Value Array.[/]");
            AnsiConsole.MarkupLine("[blue]5. Empty Array.[/]");
            AnsiConsole.MarkupLine("[blue]6. Single-Element Array.[/]");
            AnsiConsole.MarkupLine("[blue]0. Exit[/]");

            int choice = Helpers.InputHelpers.ReadMenuChoice("Choice: ", 0, 6);
            switch (choice)
            {
                case 1:
                    MenuActions.FirstArray();
                    break;
                case 2:
                    MenuActions.SortedArray();
                    break;
                case 3:
                    MenuActions.ReverseSortedArray();
                    break;
                case 4:
                    MenuActions.ArrayWithDuplicateValues();
                    break;
                case 5:
                    MenuActions.EmptyArray();
                    break;
                case 6:
                    MenuActions.SingleValueArray();
                    break;
                case 0:
                    running = false;
                    break;
            }
        }
    }
}