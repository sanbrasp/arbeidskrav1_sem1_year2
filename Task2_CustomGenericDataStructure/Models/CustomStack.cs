using Task2_CustomGenericDataStructure.Models;

namespace Task2_CustomGenericDataStructure.Models;

internal class CustomStack<T>
{
    private CustomNode<T>? _top = null;
    private int _count = 0;
    
    internal CustomNode<T> Top => _top;
    internal bool IsEmpty => _top == null;
    
    internal void Push(T value)
    {
        var newNode = new CustomNode<T>(value);
        newNode.Next = _top;
        _top = newNode;
        _count++;
    }

    internal T Pop()
    {
        throw new NotImplementedException();
    }

    internal void Peek(out T value)
    {
        throw new NotImplementedException();
    }
}