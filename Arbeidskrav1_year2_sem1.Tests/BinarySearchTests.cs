using Task1_LinearSearchAndBinarySearch.Models;

namespace Arbeidskrav1_year2_sem1.Tests;

public class BinarySearchTests
{
    [Fact]
    public void BinarySearch_FindsTarget13()
    {
        // Arrange
        int[] testArray = [2, 5, 7, 9, 11, 13, 17];
        var expectedComparisons = 5;

        // Act
        var result = Search.BinarySearch(testArray, 13);

        // Assert
        Assert.Equal(5, result);
        Assert.Equal(expectedComparisons, Search.BinaryComparisons);
    }

    [Fact]
    public void BinarySearch_DoesNotFindTarget4()
    {
        // Arrange
        int[] testArray = [2, 5, 7, 9, 11, 13, 17];
        var expectedComparisons = 4;
        
        // Act
        var result = Search.BinarySearch(testArray, 4);
        
        // Assert
        Assert.Equal(-1, result);
        Assert.Equal(expectedComparisons, Search.BinaryComparisons);
    }

    [Fact]
    public void BinarySearch_ReturnsNotFound_WhenCollectionIsEmpty()
    {
        // Arrange
        int[] emptyTestArray = [];
        var expectedComparisons = 0;
        
        // Act
        var result = Search.BinarySearch(emptyTestArray, 99);

        // Assert
        Assert.Equal(-1, result);
        Assert.Equal(expectedComparisons, Search.BinaryComparisons);
    }

    [Fact]
    public void BinarySearch_ReturnSingleValue_InSingleElementArray()
    {
        // Arrange
        int[] testArray = [ 1 ];
        var expectedComparisons = 1;

        // Act
        var result = Search.BinarySearch(testArray, 1);

        // Assert
        Assert.Equal(0, result);
        Assert.Equal(expectedComparisons, Search.BinaryComparisons);
    }

    [Fact]
    public void BinarySearch_FindsFirstOccurrence_WhenDuplicateValuesInArray()
    {
        // Arrange
        int[] arrayWithDuplicateValues = [2, 5, 7, 9, 11, 13, 17, 17];
        var expectedComparisons = 5;

        // Act
        var  result = Search.BinarySearch(arrayWithDuplicateValues, 17);
        
        // Assert
        Assert.Equal(6, result);
        Assert.Equal(expectedComparisons, Search.BinaryComparisons);
    }

    [Fact]
    public void BinarySearch_MayAccidentallySucceed_OnCertainUnsortedArray()
    {
        // Arrange
        int[] luckyArray = { 3, 25, 7, 19, 12 };

        // Act
        var result = Search.BinarySearch(luckyArray, 7);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void BinarySearch_MayFail_OnDifferentUnsortedArray_WithSameTarget()
    {
        // Arrange
        int[] unluckyArray = { 25, 3, 19, 7, 12 };

        // Act
        var result = Search.BinarySearch(unluckyArray, 7);

        // Assert
        Assert.Equal(-1, result);
    }
}