namespace Task2_CustomGenericDataStructure.Models;

/// <summary>
/// Simple custom node class for use with the <see cref="CustomStack{T}"/> class.
/// </summary>
/// <typeparam name="T">Generic type.</typeparam>
internal class CustomNode<T>
{
    private CustomNode<T>? _next;
    
    /// <summary>
    /// Gets the value of the <see cref="CustomNode{T}"/>.
    /// </summary>
    internal T Value { get; }

    /// <summary>
    /// Stores the next node.
    /// </summary>
    internal CustomNode<T>? Next
    {
        get => _next;
        set => _next = value;
    }

    /// <summary>
    /// Constructor that initializes a new <see cref="CustomNode{T}"/>
    /// object with <paramref name="value"/>, and a default null value for _next.
    /// </summary>
    /// <param name="value"></param>
    internal CustomNode(T value)
    {
        Value = value;
        _next = null;
    }
}