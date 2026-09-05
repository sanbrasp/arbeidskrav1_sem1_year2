using Task1_LinearSearchAndBinarySearch.Models;

namespace Arbeidskrav1_year2_sem1.Tests;

public class LinearSearchTests
{
    [Fact]
    public void LinearSearch_FindsTarget7_InTestArray()
    {
        // Arrange
        int[] testArray = [8, 3, 11, 7, 2, 9, 5];
        var expectedComparisons = 4;

        // Act
        var result = Search.LinearSearch(testArray, 7);

        // Assert
        Assert.Equal(3, result);
        Assert.Equal(expectedComparisons, Search.LinearComparisons);
    }

    [Fact]
    public void LinearSearch_DoesNotFindTarget42_InTestArray()
    {
        // Arrange
        int[] testArray = [8, 3, 11, 7, 2, 9, 5];
        var expectedComparisons = 7;

        // Act
        var result = Search.LinearSearch(testArray, 42);

        // Assert
        Assert.Equal(-1, result);
        Assert.Equal(expectedComparisons, Search.LinearComparisons);
    }
    
    [Fact]
    public void LinearSearch_ReturnsNotFound_WhenCollectionIsEmpty()
    {
        // Arrange
        int[] emptyArray = [];
        var expectedComparisons = 0;

        // Act
        var result = Search.LinearSearch(emptyArray, 10);

        // Assert
        Assert.Equal(-1, result);
        Assert.Equal(expectedComparisons, Search.LinearComparisons);
    }

    [Fact]
    public void LinearSearch_ReturnSingleValue_InSingleElementArray()
    {
        // Arrange
        int[] singleElementArray = [ 1 ];
        var expectedComparisons = 1;

        // Act
        var result = Search.LinearSearch(singleElementArray, 1);

        // Assert
        Assert.Equal(0, result);
        Assert.Equal(expectedComparisons, Search.LinearComparisons);
    }

    [Fact]
    public void LinearSearch_FindsFirstOccurrence_WhenDuplicateValuesInArray()
    {
        // Arrange
        int[] arrayWithDuplicateValues = [8, 3, 11, 7, 2, 9, 5, 2];
        var expectedComparisons = 5;
        
        // Act
        var result = Search.LinearSearch(arrayWithDuplicateValues, 2);

        // Assert
        Assert.Equal(4, result);
        Assert.Equal(expectedComparisons, Search.LinearComparisons);
    }
}