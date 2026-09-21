using Task4_GraphAndBFS.Models;
using Task5_DFSAndComparison.SearchAlgorithms;

namespace Arbeidskrav1_year2_sem1.Tests;

public class DfsTests
{
    private readonly Graph _graph;
    
    public DfsTests()
    {
        _graph = new Graph();
        _graph.AddConnection("Majorstuen", "Nationaltheatret");
        _graph.AddConnection("Nationaltheatret", "Stortinget");
        _graph.AddConnection("Stortinget", "Jernbanetorget");
        _graph.AddConnection("Jernbanetorget", "Grønland");    
        _graph.AddConnection("Grønland", "Tøyen");
        _graph.AddConnection("Majorstuen", "Blindern");
        _graph.AddConnection("Blindern", "Forskningsparken");
        _graph.AddConnection("Forskningsparken", "Ullevål Stadion");
    }

    [Fact]
    public void RecursiveDfs_ReturnsCorrectVisitOrder_FromMajorstuen()
    {
        // Arrange
        List<string> expectedOrder = ["Majorstuen", "Nationaltheatret", "Stortinget", "Jernbanetorget", "Grønland", 
        "Tøyen", "Blindern", "Forskningsparken", "Ullevål Stadion"];

        // Act
        var result = Search.RecursiveDfs(_graph.GetAdjacencyList(), "Majorstuen");

        // Assert
        Assert.Equal(expectedOrder, result);
    }

    [Fact]
    public void RecursiveDfs_HandlesMissingStartNode()
    {
        // Arrange
        var extectedResult = new List<string>();

        // Act
        var result = Search.RecursiveDfs(_graph.GetAdjacencyList(), "Månen");

        // Assert
        Assert.Equal(extectedResult, result);
    }

    [Theory]
    [InlineData("Majorstuen")]
    [InlineData("Tøyen")]
    public void RecursiveDfs_DoesNotReachIsolatedStationLeirfjord_FromAnywhere(string startNode)
    {
        // Arrange
        _graph.AddNode("Leirfjord");
        
        // Act
        var result = Search.RecursiveDfs(_graph.GetAdjacencyList(), startNode);

        // Assert
        Assert.DoesNotContain("Leirfjord", result);
    }

    [Fact]
    public void DetectCycles_DoesNotDetectCycles_WhereThereAreNoCycles()
    {
        // Arrange
        var expectedResult = new List<(string, string)>();

        // Act
        Search.DetectCycles(_graph.GetAdjacencyList(), "Majorstuen", out List<(string, string)> cycles);

        // Assert
        Assert.Empty(cycles);
        Assert.Equal(expectedResult.Count, cycles.Count);
    }

    [Fact]
    public void DetectCycles_DetectsCycles_WhereThereAreCycles()
    {
        // Arrange
        _graph.AddConnection("Tøyen", "Majorstuen");
        List<(string, string)> expectedResult = new() { ("Majorstuen", "Tøyen") };
        
        // Act
        Search.DetectCycles(_graph.GetAdjacencyList(), "Majorstuen",out List<(string, string)> cycles);

        // Assert
        Assert.NotEmpty(cycles);
        Assert.Equal(expectedResult, cycles);
    }

    [Fact]
    public void IterativeDfs_ReturnsCorrectVisitOrder_FromMajorstuen()
    {
        // Arrange
        List<string> expectedOrder = ["Majorstuen", "Nationaltheatret", "Stortinget", "Jernbanetorget", "Grønland", 
            "Tøyen", "Blindern", "Forskningsparken", "Ullevål Stadion"];

        // Act
        var result = Search.IterativeDfs(_graph.GetAdjacencyList(), "Majorstuen");

        // Assert
        Assert.Equal(expectedOrder, result);
    }

    [Fact]
    public void IterativeDfsAndRecursiveDfs_ReturnIdenticalVisitOrder()
    {
        // Arrange

        // Act
        var iterativeResult = Search.IterativeDfs(_graph.GetAdjacencyList(), "Majorstuen");
        var recursiveResult = Search.RecursiveDfs(_graph.GetAdjacencyList(), "Majorstuen");

        // Assert
        Assert.Equal(iterativeResult, recursiveResult);
    }

    [Fact]
    public void IterativeDfs_HandlesMissingStartNode()
    {
        // Arrange
        var extectedResult = new List<string>();

        // Act
        var result = Search.IterativeDfs(_graph.GetAdjacencyList(), "Månen");

        // Assert
        Assert.Equal(extectedResult, result);
    }

    [Theory]
    [InlineData("Majorstuen", "Leirfjord")]
    [InlineData("Månen", "Jernbanetorget")]
    [InlineData("Sola", "Månen")]
    public void FindRoute_ReturnsFalse_OnNoRouteAndMissingStartAndTarget(string start, string end)
    {
        // Arrange
        _graph.AddNode("Leirfjord"); // isolated node

        // Act
        bool result = Search.FindRoute(_graph.GetAdjacencyList(), start, end);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("Majorstuen", "Forskningsparken")]
    [InlineData("Tøyen", "Stortinget")]
    public void FindRoute_ReturnsTrue_OnExistingRoute(string start, string end)
    {
        // Arrange
        

        // Act
        bool result = Search.FindRoute(_graph.GetAdjacencyList(), start, end);

        // Assert
        Assert.True(result);
    }
}