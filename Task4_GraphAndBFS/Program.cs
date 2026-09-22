using Spectre.Console;
using Task4_GraphAndBFS.Menu;
using Task4_GraphAndBFS.Models;
using Task4_GraphAndBFS.Search;

namespace Task4_GraphAndBFS;

class Program
{
    static void Main(string[] args)
    {
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
            AnsiConsole.Write(new Panel("[green bold]Task 4 - Graph and BFS Demonstration[/]")
                .SquareBorder());
            AnsiConsole.MarkupLine("[green]Choose option:[/]");
            AnsiConsole.MarkupLine("[blue]1. BFS from 'Majorstuen'.[/]");
            AnsiConsole.MarkupLine("[blue]2. ShortestPath between 'Majorstuen' and 'Grønland'.[/]");
            AnsiConsole.MarkupLine("[blue]3. ShortestPath between 'Ullevål Stadion' and 'Tøyen'.[/]");
            AnsiConsole.MarkupLine("[blue]4. BFS - Isolated Station Not Reached.[/]");
            AnsiConsole.MarkupLine("[blue]5. ShortestPath - Isolated Station Not Reached[/]");
            AnsiConsole.MarkupLine("[blue]0. Exit[/]");

            int choice = Helpers.InputHelpers.ReadMenuChoice("Choice: ", 0, 5);
            switch (choice)
            {
                case 1:
                    MenuActions.BfsFromMajorstuen(graph);
                    break;
                case 2:
                    MenuActions.ShortestPathMajorstuenGronland(graph);
                    break;
                case 3:
                    MenuActions.ShortestPathUllevalToyen(graph);
                    break;
                case 4:
                    MenuActions.BfsIsolatedStation(graph);
                    break;
                case 5:
                    MenuActions.ShortestPathIsolatedStation(graph);
                    break;
                case 0:
                    running = false;
                    break;
            }
        }
    }
}