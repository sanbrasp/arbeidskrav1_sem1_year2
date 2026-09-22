using Spectre.Console;
using Task4_GraphAndBFS.Models;
using Task4_GraphAndBFS.Search;

namespace Task4_GraphAndBFS.Menu;

internal static class MenuActions
{
    internal static void BfsFromMajorstuen(Graph graph)
    {
        AnsiConsole.Clear();
        AnsiConsole.Write(new Panel("[green bold]Run BFS from 'Majorstuen' on the Graph:[/]")
            .RoundedBorder());
        AnsiConsole.MarkupLine("[green]Expected result order:[/]\n" +
                               "[blue]Majorstuen, Nationaltheatret, Blindern, Stortinget, " +
                               "Forskningsparken, Jernbanetorget, Ullevål Stadion, Grønland, Tøyen[/]");
        
        var result = BreadthFirstSearch.Bfs(graph.GetAdjacencyList(), "Majorstuen");
        
        AnsiConsole.MarkupLine("[green]Actual result order:[/]");
        int number = 1;
        foreach (var key in result)
        {
            
            AnsiConsole.MarkupLine($"[blue]{number++} - {key}[/]");
        }
        Helpers.FlowHelpers.Pause();
    }

    internal static void ShortestPathMajorstuenGronland(Graph graph)
    {
        AnsiConsole.Clear();
        AnsiConsole.Write(new Panel("[green bold]Find ShortestPath between 'Majorstuen' and 'Grønland':[/]")
            .RoundedBorder());
        AnsiConsole.MarkupLine($"[green]Shortest Path from 'Majorstuen' to 'Grønland':[/] " +
                               $"[blue]{BreadthFirstSearch.ShortestPath(graph.GetAdjacencyList(), 
                                   "Majorstuen", "Grønland")}[/]");
        Helpers.FlowHelpers.Pause();
    }

    internal static void ShortestPathUllevalToyen(Graph graph)
    {
        AnsiConsole.Clear();
        AnsiConsole.Write(new Panel("[green bold]Route between 'Ullevål Stadion' and 'Tøyen':[/]")
            .RoundedBorder());
        AnsiConsole.MarkupLine($"[green]Shortest Path from 'Ullevål Stadion' to 'Tøyen':[/] " + 
                               $"[blue]{BreadthFirstSearch.ShortestPath(graph.GetAdjacencyList(),
                                   "Ullevål Stadion", "Tøyen")}[/]");
        Helpers.FlowHelpers.Pause();
    }

    internal static void BfsIsolatedStation(Graph graph)
    {
        AnsiConsole.Clear();
        AnsiConsole.Write(new Panel("[green bold]Isolated Station, traversal skip:[/]")
            .RoundedBorder());
        graph.AddNode("Leirfjord");
        AnsiConsole.MarkupLine("[green]'Leirfjord' added as isolated station.[/]");
        AnsiConsole.MarkupLine("[green]BFS result from 'Majorstuen';'Leirfjord' is absent: [/]");
        
        var disconnectedBfs = BreadthFirstSearch.Bfs(graph.GetAdjacencyList(), "Majorstuen");
        foreach (var key in disconnectedBfs)
        {
            AnsiConsole.MarkupLine($"[blue]{key}[/]");
        }
        Helpers.FlowHelpers.Pause();
    }

    internal static void ShortestPathIsolatedStation(Graph graph)
    {
        AnsiConsole.Clear();
        AnsiConsole.Write(new Panel("[green bold]Isolated Station, no-route result[/]")
            .RoundedBorder());
        graph.AddNode("Leirfjord");
        AnsiConsole.MarkupLine($"[green]ShortestPath noResult using 'Leirfjord' as target: [/]" + 
                               $"[blue]{BreadthFirstSearch.ShortestPath(graph.GetAdjacencyList(),
                                   "Majorstuen", "Leirfjord")}[/]");
        Helpers.FlowHelpers.Pause();
    }
}