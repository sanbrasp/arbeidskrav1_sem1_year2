namespace Task2_CustomGenericDataStructure.Models;

internal class CustomNode<T>
{
    private CustomNode<T>? _next;
    
    internal T Value { get; }

    internal CustomNode<T>? Next
    {
        get => _next;
        set => _next = value;
    }

    public CustomNode(T value)
    {
        Value = value;
        _next = null;
    }
}