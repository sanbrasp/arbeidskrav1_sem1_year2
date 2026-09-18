namespace Task4_GraphAndBFS.Models;

internal class Graph
{
    private readonly Dictionary<string, List<string>> _adjacencyList = new();

    /// <summary>
    /// Adds stations A and B to adjacency list.
    /// </summary>
    /// <param name="stationA">The first stations (start).</param>
    /// <param name="stationB">The last station (end).</param>
    internal void AddStation(string stationA, string stationB)
    {
        AddNode(stationA);
        AddNode(stationB);
        
        _adjacencyList[stationA].Add(stationB);
        _adjacencyList[stationB].Add(stationA);
    }
    
    private void AddNode(string node)
    {
        if (!_adjacencyList.ContainsKey(node))
        {
            _adjacencyList[node] = new List<string>();
        }
    }

    /// <summary>
    /// Gets a copy of the adjacency list.
    /// </summary>
    /// <returns></returns>
    internal Dictionary<string, List<string>> GetAdjacencyList()  
    {
        Dictionary<string, List<string>> adjacencyListCopy = new();
        foreach (var key in _adjacencyList)
        {
            adjacencyListCopy.Add(key.Key, new List<string>(key.Value));
        }

        return adjacencyListCopy;
    }
}