using Task4_GraphAndBFS.Models;
using Task5_DFSAndComparison.SearchAlgorithms;

namespace Task5_DFSAndComparison;

class Program
{
    static void Main(string[] args)
    {
        // testing
        var graph = new Graph();
        graph.AddConnection("Majorstuen", "Nationaltheatret");
        graph.AddConnection("Nationaltheatret", "Stortinget");
        graph.AddConnection("Stortinget", "Jernbanetorget");
        graph.AddConnection("Jernbanetorget", "Grønland");    
        graph.AddConnection("Grønland", "Tøyen");
        graph.AddConnection("Majorstuen", "Blindern");
        graph.AddConnection("Blindern", "Forskningsparken");
        graph.AddConnection("Forskningsparken", "Ullevål Stadion");

        Console.WriteLine("Traversal test:");
        var result = (Search.RecursiveDfs(graph.GetAdjacencyList(), "Majorstuen", out var cycles1));
        int count = 0;
        foreach (var item in result)
        {
            Console.WriteLine($"{count++}: {item}");
        }

        Console.WriteLine();

        Console.WriteLine("Hypothetical extra edge test:");
        graph.AddConnection("Tøyen", "Majorstuen");
        var hypresult = Search.RecursiveDfs(graph.GetAdjacencyList(), "Majorstuen", out var cycles);
        int counter = 0;
        foreach (var item in hypresult)
        {
            Console.WriteLine($"{counter++}: {item}");
        }

        Console.WriteLine();
        Console.WriteLine("Looking for cycles:");
        foreach (var item in cycles)
        {
            Console.WriteLine($"Cycles found: {item}");
        }
        
    }
}