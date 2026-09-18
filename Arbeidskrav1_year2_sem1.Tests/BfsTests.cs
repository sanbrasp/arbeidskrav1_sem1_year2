using Task4_GraphAndBFS.Models;
using Task4_GraphAndBFS.Search;

namespace Arbeidskrav1_year2_sem1.Tests;

public class BfsTests
{
    private readonly Graph _graph;
    
    public BfsTests()
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
    public void Bfs_ReturnsCorrectOrder_FromStartNode()
    {
        // Arrange
        List<string> expectedOrder =
        [
            "Majorstuen", "Nationaltheatret", "Blindern", "Stortinget",
            "Forskningsparken", "Jernbanetorget", "Ullevål Stadion", "Grønland", "Tøyen"
        ];
        
        // Act
        var order = BreadthFirstSearch.Bfs(_graph.GetAdjacencyList(), "Majorstuen");
        
        // Assert
        Assert.Equal(expectedOrder, order);
    }

    [Fact]
    public void ShortestPath_ReturnsShortestPath_FromMajorstuenToGronland()
    {
        // Arrange
        int expectedSteps = 4;
        
        // Act
        var actualSteps = BreadthFirstSearch.ShortestPath(_graph.GetAdjacencyList(), "Majorstuen", "Grønland");

        // Assert
        Assert.Equal(expectedSteps, actualSteps);
    }

    [Fact]
    public void ShortestPath_ReturnsShortestPath_FromUllevaalToToyen()
    {
        // Arrange
        int expectedSteps = 8;

        // Act
        var actualSteps = BreadthFirstSearch.ShortestPath(_graph.GetAdjacencyList(), "Ullevål Stadion", "Tøyen");

        // Assert
        Assert.Equal(expectedSteps, actualSteps);
    }

    [Fact]
    public void Bfs_DoesNotReachDisconnectedStation()
    {
        // Arrange
        _graph.AddNode("Leirfjord");

        // Act
        var result = BreadthFirstSearch.Bfs(_graph.GetAdjacencyList(), "Majorstuen");

        // Assert
        Assert.DoesNotContain("Leirfjord", result);
    }
    
    [Fact]
    public void ShortestPath_ReturnsNotFound_OnDisconnectedStation()
    {
        // Arrange
        _graph.AddNode("Leirfjord");

        var expectedResult = -1;
        
        // Act
        var attemptReach = BreadthFirstSearch.ShortestPath(_graph.GetAdjacencyList(), "Majorstuen", "Leirfjord");

        // Assert
        Assert.Equal(expectedResult, attemptReach);
    }

    [Fact]
    public void Bfs_ReturnsEmptyList_WhenStartNodeDoesNotExist()
    {
        // Arrange
        // nothing to arrange here

        // Act
        var result = BreadthFirstSearch.Bfs(_graph.GetAdjacencyList(), "Ingenmannsland");

        // Assert
        Assert.Empty(result);
    }
    
    [Theory]
    [InlineData("Ingenmannsland", "Majorstuen")]
    [InlineData("Majorstuen", "Ingenmannsland")]
    [InlineData("Ingenmannsland", "Huttiheita")]
    public void ShortestPath_ReturnsNotFound_WhenStartAndOrTargetNodeDoesNotExist(string start, string target)
    {
        // Arrange
        int expectedResult = -1;

        // Act
        var actualResult = BreadthFirstSearch.ShortestPath(_graph.GetAdjacencyList(), start, target);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }
}