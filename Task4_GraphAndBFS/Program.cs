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
        
        
        var result = BreadthFirstSearch.Bfs(graph.GetAdjacencyList(), "Majorstuen");
        
        // Console.WriteLine(BreadthFirstSearch.ShortestPath(graph.GetAdjacencyList(), "Majorstuen", "Grønland"));
        
        
        foreach (var key in result)
        {
            Console.WriteLine(key);
        }
    }
}