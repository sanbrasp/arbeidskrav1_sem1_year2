namespace Task2_CustomGenericDataStructure.Models;

internal class CustomNode<T>
{
    private T _value;
    private CustomNode<T> _next;
    
    public T Value  => _value;
    public CustomNode<T> Next => _next;

    public CustomNode(T value)
    {
        _value = value;
        _next = null;
    }
}