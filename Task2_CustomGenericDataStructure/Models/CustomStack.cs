using Task2_CustomGenericDataStructure.Models;

namespace Task2_CustomGenericDataStructure.Models;

/// <summary>
/// A generic custom stack class.
/// </summary>
internal class CustomStack<T>
{
    /// <summary>
    /// Reference to <see cref="CustomNode{T}"/> _top field.
    /// </summary>
    private CustomNode<T>? _top = null;
    
    /// <summary>
    /// Displays the value of <see cref="CustomNode{T}"/> _top field.
    /// </summary>
    internal CustomNode<T>? Top => _top;
    
    /// <summary>
    /// Checks if _top is null/empty.
    /// </summary>
    private bool IsEmpty => _top == null;
    
    /// <summary>
    /// Pushes a new node and puts it at the top of the stack.
    /// </summary>
    /// <param name="value">The value of the node.</param>
    internal void Push(T value)
    {
        var newNode = new CustomNode<T>(value); // store the node's value in newNode
        newNode.Next = _top; // assign the next value in the currently empty _top
        _top = newNode; // assign newNode to _top
    }

    /// <summary>
    /// Pops the top node off and assigns the next node to the top.
    /// </summary>
    /// <returns>The value of the top node.</returns>
    /// <exception cref="InvalidOperationException">Throws if top is empty.</exception>
    internal T Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        var node = _top;
        var nextNode = node.Next;
        _top = nextNode;
        
        return node.Value;
    }

    /// <summary>
    /// Peeks at the top node, and returns its value.
    /// </summary>
    /// <returns>The value of the top node.</returns>
    /// <exception cref="InvalidOperationException">Throws if top is empty.</exception>
    internal T Peek()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        
        return _top.Value;
    }
}