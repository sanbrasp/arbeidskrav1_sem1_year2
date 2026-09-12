using Task3_DivideAndConquer.Models;

namespace Arbeidskrav1_year2_sem1.Tests;

public class MergeSortTests
{
    [Fact]
    public void MergeSort_ReturnsCorrectResult()
    {
        // Arrange
        int[] taskSpecifiedArray = [64, 34, 25, 12, 22, 11, 90];
        int[] expectedOrder = [11, 12, 22, 25, 34, 64, 90];
        int expectedComparisonCount;
        int expectedMergeCallCount;
        
        // Act
        Sort.ResetAndRunMergeSort(taskSpecifiedArray);

        // Assert
        Assert.Equal(expectedOrder, taskSpecifiedArray);
    }
}