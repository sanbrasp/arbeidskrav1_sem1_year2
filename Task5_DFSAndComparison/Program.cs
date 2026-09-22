using Spectre.Console;
using Task4_GraphAndBFS.Models;
using Task5_DFSAndComparison.SearchAlgorithms;

namespace Task5_DFSAndComparison;

class Program
{
    static void Main(string[] args)
    {
        // reused graph from task 4
        var graph = new Graph();
        graph.AddConnection("Majorstuen", "Nationaltheatret");
        graph.AddConnection("Nationaltheatret", "Stortinget");
        graph.AddConnection("Stortinget", "Jernbanetorget");
        graph.AddConnection("Jernbanetorget", "Grønland");    
        graph.AddConnection("Grønland", "Tøyen");
        graph.AddConnection("Majorstuen", "Blindern");
        graph.AddConnection("Blindern", "Forskningsparken");
        graph.AddConnection("Forskningsparken", "Ullevål Stadion");

        AnsiConsole.Write(new Panel("[green bold]Recursive DFS from 'Majorstuen':[/]")
            .RoundedBorder());
        var result = (Search.RecursiveDfs(graph.GetAdjacencyList(), "Majorstuen"));
        int count = 1;
        foreach (var item in result)
        {
            AnsiConsole.MarkupLine($"[blue]{count++}: {item}[/]");
        }

        Console.WriteLine();
        
        AnsiConsole.Write(new Panel("[green bold]Iterative DFS from 'Majorstuen':[/]")
            .RoundedBorder());;
        var iterResult = Search.IterativeDfs(graph.GetAdjacencyList(), "Majorstuen");
        var itCount = 1;
        foreach (var item in iterResult)
        {
            AnsiConsole.MarkupLine($"[blue]{itCount++}: {item}[/]");
        }

        Console.WriteLine();
        
        AnsiConsole.Write(new Panel("[green bold]Detect Cycles:[/]")
            .RoundedBorder());
        AnsiConsole.MarkupLine("[green]Hypothetical extra edge test.\n" +
                               "Adding Connection 'Tøyen', 'Majorstuen'.[/]");
        graph.AddConnection("Tøyen", "Majorstuen");
        AnsiConsole.MarkupLine("[green]Running DetectCycles test:[/]");
        Search.DetectCycles(graph.GetAdjacencyList(), "Majorstuen", out var cycles);
        foreach (var item in cycles)
        {
            AnsiConsole.MarkupLine($"[blue]Result: {item}[/]");
        }

        Console.WriteLine();
        AnsiConsole.Write(new Panel("[green bold]Isolated Node Test[/]"));
        AnsiConsole.MarkupLine("[green]Adding isolated node: 'Leirfjord'[/]");
        graph.AddNode("Leirfjord");
        AnsiConsole.MarkupLine("[green]Running FindRoute from 'Majorstuen' to 'Leirfjord':[/]");
        bool isolatedRouteResult = Search.FindRoute(graph.GetAdjacencyList(), "Majorstuen", "Leirfjord");
        AnsiConsole.MarkupLine($"[red]{isolatedRouteResult}[/]");

        Console.WriteLine();
        AnsiConsole.MarkupLine("[green]Running FindRoute from 'Majorstuen' to 'Tøyen':[/]");
        bool shouldBeTrue  = Search.FindRoute(graph.GetAdjacencyList(), "Majorstuen", "Tøyen");
        AnsiConsole.MarkupLine($"[blue]{shouldBeTrue}[/]");
    }
}