using Spectre.Console;
using Task4_GraphAndBFS.Models;
using Task5_DFSAndComparison.Menu;
using Task5_DFSAndComparison.Helpers;
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

        bool running = true;
        while (running)
        {
            AnsiConsole.Write(new Panel("[green bold]DFS Demonstration[/]")
                .RoundedBorder());
            
            AnsiConsole.MarkupLine("[green]1. Recursive DFS from 'Majorstuen'.[/]");
            AnsiConsole.MarkupLine("[green]2. Iterative DFS from 'Majorstuen'.[/]");
            AnsiConsole.MarkupLine("[green]3. Detect Cycles.[/]");
            AnsiConsole.MarkupLine("[green]4. FindRoute - Isolated Node.[/]");
            AnsiConsole.MarkupLine("[green]5. FindRoute - 'Majorstuen', 'Tøyen'.[/]");
            AnsiConsole.MarkupLine("[green]0. Exit.[/]");

            int choice = InputHelpers.ReadMenuChoice("Choice: ", 0, 5);
            switch (choice)
            {
                case 1:
                    MenuActions.RecursiveDfsFromMajorstuen(graph);
                    break;
                case 2:
                    MenuActions.IterativeDfsFromMajorstuen(graph);
                    break;
                case 3:
                    MenuActions.DetectCyclesExtension();
                    break;
                case 4:
                    MenuActions.FindRouteIsolatedNode(graph);
                    break;
                case 5:
                    MenuActions.FindRouteMajorstuenToyen(graph);
                    break;
                case 0:
                    running = false;
                    break;
            }
        }
    }
}