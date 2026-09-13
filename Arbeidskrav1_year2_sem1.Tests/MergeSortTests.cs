using Task3_DivideAndConquer.Models;

namespace Arbeidskrav1_year2_sem1.Tests;

public class MergeSortTests
{
    [Fact]
    public void MergeSort_SortsCorrectly_AndCountsComparisonsAndMerges_ForTaskSpecifiedArray()
    {
        // Arrange
        int[] taskSpecifiedArray = [64, 34, 25, 12, 22, 11, 90];
        int[] expectedOrder = [11, 12, 22, 25, 34, 64, 90];
        int expectedComparisonCount= 13;
        int expectedMergeCallCount = 6;
        
        // Act
        Sort.ResetAndRunMergeSort(taskSpecifiedArray);

        // Assert
        Assert.Equal(expectedOrder, taskSpecifiedArray);
        Assert.Equal(expectedComparisonCount, Sort.ComparisonCounter);
        Assert.Equal(expectedMergeCallCount, Sort.MergeCallCounter);
    }

    [Fact]
    public void MergeSort_SortsCorrectly_AndCountsComparisonsAndMerges_ForSortedArray()
    {
        // Arrange
        int[] sortedArray = [1, 2, 3, 4, 5];
        int[] expectedOrder = [1, 2, 3, 4, 5];
        int expectedComparisonCount = 7;
        int expectedMergeCallCount = 4;

        // Act
        Sort.ResetAndRunMergeSort(sortedArray);

        // Assert
        Assert.Equal(expectedOrder, sortedArray);
        Assert.Equal(expectedComparisonCount, Sort.ComparisonCounter);
        Assert.Equal(expectedMergeCallCount, Sort.MergeCallCounter);
    }

    [Fact]
    public void MergeSort_SortsCorrectly_AndCountsComparisonsAndMerges_ForReverseSortedArray()
    {
        // Arrange
        int[] reverseSortedArray = [9, 8, 7, 6, 5];
        int[] expectedOrder = [5, 6, 7, 8, 9];
        int expectedComparisonCount = 5;
        int expectedMergeCallCount = 4;

        // Act
        Sort.ResetAndRunMergeSort(reverseSortedArray);

        // Assert
        Assert.Equal(expectedOrder, reverseSortedArray);
        Assert.Equal(expectedComparisonCount, Sort.ComparisonCounter);
        Assert.Equal(expectedMergeCallCount, Sort.MergeCallCounter);
    }

    [Fact]
    public void MergeSort_SortsCorrectly_AndCountsComparisonsAndMerges_ForArrayWithDuplicateElements()
    {
        // Arrange
        int[] arrayWithDuplicates = [2, 22, 67, 7, 12, 27, 17, 2];
        int[] expectedOrder = [2, 2, 7, 12, 17, 22, 27, 67];
        int expectedComparisonCount = 17;
        int expectedMergeCallCount = 7;

        // Act
        Sort.ResetAndRunMergeSort(arrayWithDuplicates);

        // Assert
        Assert.Equal(expectedOrder, arrayWithDuplicates);
        Assert.Equal(expectedComparisonCount, Sort.ComparisonCounter);
        Assert.Equal(expectedMergeCallCount, Sort.MergeCallCounter);
    }

    [Fact]
    public void MergeSort_HandlesEmptyArray_AndCountersAreAtZero()
    {
        // Arrange
        int[] emptyArray = [];
        int expectedComparisonCount = 0;
        int expectedMergeCallCount = 0;

        // Act
        Sort.ResetAndRunMergeSort(emptyArray);

        // Assert
        Assert.Equal(expectedComparisonCount, Sort.ComparisonCounter);
        Assert.Equal(expectedMergeCallCount, Sort.MergeCallCounter);
    }

    [Fact]
    public void MergeSort_HandlesSingleElementArray_AndCountersAreAtZero()
    {
        // Arrange
        int[] singleValueArray = [1024];
        int expectedComparisonCount = 0;
        int expectedMergeCallCount = 0;

        // Act
        Sort.ResetAndRunMergeSort(singleValueArray);

        // Assert
        Assert.Equal(expectedComparisonCount, Sort.ComparisonCounter);
        Assert.Equal(expectedMergeCallCount, Sort.MergeCallCounter);
    }
}