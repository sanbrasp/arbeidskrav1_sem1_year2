using Task4_GraphAndBFS.Models;

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
    }
}