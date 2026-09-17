using System.Globalization;
using Task4_GraphAndBFS.Models;
using Task4_GraphAndBFS.Search;

namespace Task4_GraphAndBFS;

class Program
{
    static void Main(string[] args)
    {
        // var adjacencyList = new Dictionary<string, List<string>>();
        var graph = new Graph();
        graph.AddStation("Majorstuen", "Nationaltheatret");
        graph.AddStation("Nationaltheatret", "Stortinget");
        graph.AddStation("Stortinget", "Jernbanetorget");
        graph.AddStation("Jernbanetorget", "Grønland");    
        graph.AddStation("Grønland", "Tøyen");
        graph.AddStation("Majorstuen", "Blindern");
        graph.AddStation("Blindern", "Forskningsparken");
        graph.AddStation("Forskningsparken", "Ullevål Stadion");
        
        BreathFirstSearch.Bfs(graph.GetAdjacencyList(), "Majorstuen");
        Console.WriteLine(graph.GetAdjacencyList().Count);
        foreach (var node in graph.GetAdjacencyList())
        {
            Console.WriteLine(node.Key);
        }
    }
}