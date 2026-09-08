using Spectre.Console;
using Task1_LinearSearchAndBinarySearch.Models;

namespace Task1_LinearSearchAndBinarySearch.Display;

/// <summary>
/// Static class that represents a display of <see cref="SearchResult"/>.
/// </summary>
internal static class DisplayResult
{
    internal static void ShowTable(IEnumerable<SearchResult> results)
    {
        var table = new Table();
        table.Border(TableBorder.Rounded);
        table.AddColumn("Algorithm");
        table.AddColumn("Target");
        table.AddColumn("Index Found");
        table.AddColumn("Comparisons");
        table.AddColumn("Sorted input?");

        foreach (var result in results)
        {
            table.AddRow(
                result.AlgorithmName,
                result.Target.ToString(),
                result.Index.ToString(),
                result.Comparisons.ToString(),
                result.ArrayIsSorted ? "Yes" : "No"
            );
        }
        AnsiConsole.Write(table);
    }
}