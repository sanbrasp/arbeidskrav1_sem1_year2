using Task2_CustomGenericDataStructure.Models;

namespace Task2_CustomGenericDataStructure.Models;

internal class CustomStack<T>
{
    private CustomNode<T>? _top = null;
    
    internal CustomNode<T>? Top => _top;
    private bool IsEmpty => _top == null;
    
    
    internal void Push(T value)
    {
        var newNode = new CustomNode<T>(value);
        newNode.Next = _top;
        _top = newNode;
    }

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

    internal void Peek(out T value)
    {
        throw new NotImplementedException();
    }
}