using System.Globalization;
using System.Runtime.CompilerServices;
using Task4_GraphAndBFS.Models;
using Task4_GraphAndBFS.Search;

namespace Task4_GraphAndBFS;

class Program
{
    static void Main(string[] args)
    {
        var graph = new Graph();
        graph.AddStation("Majorstuen", "Nationaltheatret");
        graph.AddStation("Nationaltheatret", "Stortinget");
        graph.AddStation("Stortinget", "Jernbanetorget");
        graph.AddStation("Jernbanetorget", "Grønland");    
        graph.AddStation("Grønland", "Tøyen");
        graph.AddStation("Majorstuen", "Blindern");
        graph.AddStation("Blindern", "Forskningsparken");
        graph.AddStation("Forskningsparken", "Ullevål Stadion");
        
        // Run and document BFS from "Majorstuen":
        var result = BreadthFirstSearch.Bfs(graph.GetAdjacencyList(), "Majorstuen");
        Console.WriteLine("Expected result order:\n" +
                          "Majorstuen, Nationaltheatret, Blindern, Stortinget, " +
                          "Forskningsparken, Jernbanetorget, Ullevål Stadion, Grønland, Tøyen");
        Console.WriteLine("Actual result order:");
        int number = 1;
        foreach (var key in result)
        {
            
            Console.WriteLine($"{number++} - {key}");
        }
        
        // Run ShortestPath from "Majorstuen" to "Grønland":
        Console.WriteLine();
        Console.WriteLine($"Shortest Path from 'Majorstuen' to 'Grønland': " +
                          $"{BreadthFirstSearch.ShortestPath(graph.GetAdjacencyList(), "Majorstuen", "Grønland")}");
        
    }
}