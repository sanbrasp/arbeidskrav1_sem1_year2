using Task2_CustomGenericDataStructure.Models;

namespace Arbeidskrav1_year2_sem1.Tests;

/// <summary>
/// A collection of tests focused on the <see cref="CustomStack{T}"/> and
/// <see cref="CustomNode{T}"/> classes for Task 2 - Custom Generic Data Structure.
/// </summary>
public class CustomStackTests
{
    [Fact]
    public void CustomStack_PushFollowedByPeek_ReturnsTheCorrectValue()
    {
        // Arrange
        var stack = new CustomStack<int>();

        // Act
        stack.Push(1);
        stack.Push(2);
        stack.Peek();

        // Assert
        Assert.Equal(2, stack.Peek());
    }

    [Fact]
    public void CustomStack_PushFollowedByPop_ConfirmsCorrectLifoOrder()
    {
        // Arrange
        var stack = new CustomStack<int>();

        // Act
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Assert
        Assert.Equal(3, stack.Pop());
    }
    
    [Fact]
    public void CustomStack_CatchesInvalidOperationException_OnPop_WhenStackIsEmpty()
    {
        // Arrange
        var stack = new CustomStack<int>();

        // Act and Assert
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }
    
    [Fact]
    public void CustomStack_CatchesInvalidOperationException_OnPeek_WhenStackIsEmpty()
    {
        // Arrange
        var stack = new CustomStack<int>();

        // Act and Assert
        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }
    
    [Fact]
    public void CustomStack_IsEmpty_ReflectsCorrectState_BeforePushing_And_AfterPopping()
    {
        // Arrange
        var stack = new CustomStack<int>();
        
        // Act and Assert
        Assert.True(stack.IsEmpty);
        stack.Push(1);
        Assert.False(stack.IsEmpty);
        stack.Pop();
        Assert.True(stack.IsEmpty);
    }
}