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

        Console.WriteLine("Recursive DFS test from 'Majorstuen':");
        var result = (Search.RecursiveDfs(graph.GetAdjacencyList(), "Majorstuen"));
        int count = 1;
        foreach (var item in result)
        {
            Console.WriteLine($"{count++}: {item}");
        }

        Console.WriteLine();
        
        Console.WriteLine("Iterative DFS test from 'Majorstuen':");
        var iterResult = Search.IterativeDfs(graph.GetAdjacencyList(), "Majorstuen");
        var itCount = 1;
        foreach (var item in iterResult)
        {
            Console.WriteLine($"{itCount++}: {item}");
        }

        Console.WriteLine();
        
        Console.WriteLine("Hypothetical extra edge test:");
        Console.WriteLine("Adding Connection: 'Tøyen', 'Majorstuen'");
        graph.AddConnection("Tøyen", "Majorstuen");
        Console.WriteLine("Running DetectCycles test:");
        Search.DetectCycles(graph.GetAdjacencyList(), "Majorstuen", out var cycles);
        foreach (var item in cycles)
        {
            Console.WriteLine("Result: " + item);
        }

        Console.WriteLine();
        Console.WriteLine("Adding isolated node: 'Leirfjord'");
        graph.AddNode("Leirfjord");
        Console.WriteLine("Running FindRoute from startNode 'Majorstuen' to targetNode: 'Leirfjord':");
        bool isolatedRouteResult = Search.FindRoute(graph.GetAdjacencyList(), "Majorstuen", "Leirfjord");
        Console.WriteLine(isolatedRouteResult);
        Console.WriteLine("Running FindRoute from startNode 'Majorstuen' to targetNode: 'Tøyen':");
        bool shouldBeTrue  = Search.FindRoute(graph.GetAdjacencyList(), "Majorstuen", "Tøyen");
        Console.WriteLine(shouldBeTrue);
    }
}