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

        // Assert
        Assert.Equal(2, stack.Peek());
    }

    [Fact]
    public void CustomStack_PushFollowedByPop_ConfirmsCorrectLifoOrder()
    {
        // Arrange
        var stack = new CustomStack<int>();

        // Act
        stack.Push(10);
        stack.Push(99);
        stack.Push(42);

        // Assert
        Assert.Equal(42, stack.Pop());
        Assert.Equal(99, stack.Pop());
        Assert.Equal(10, stack.Pop());
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

    [Fact]
    public void CustomStack_ConfirmsCorrectState_AfterTangledHistory()
    {
        // Arrange
        var stack = new CustomStack<string>();

        // Act and Assert
        stack.Push("first");
        stack.Push("second");
        Assert.Equal("second", stack.Pop());
        Assert.Equal("first", stack.Peek());
        
        stack.Push("third");
        stack.Push("fourth");
        Assert.Equal("fourth", stack.Pop());
        Assert.Equal("third", stack.Peek());
    }

    [Fact]
    public void CustomStack_AllowsValueTypeNode_OfValueZero()
    {
        // Arrange
        var stack = new CustomStack<int>();

        // Act
        stack.Push(0);

        // Assert
        Assert.Equal(0, stack.Peek());
    }

    [Fact]
    public void CustomStack_ThrowsArgumentNullException_OnPushNull()
    {
        // Arrange
        var stack = new CustomStack<string>();

        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => stack.Push(null));
    }
}