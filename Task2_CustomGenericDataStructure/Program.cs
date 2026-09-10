using Task2_CustomGenericDataStructure.Models;

namespace Task2_CustomGenericDataStructure;

class Program
{
    static void Main(string[] args)
    {
        var stack = new CustomStack<string>();

        Console.WriteLine("Pushing elements to the stack:");
        Console.WriteLine("Pushing 'A' to stack.");
        stack.Push("A");
        Console.WriteLine("Pushing 'B' to stack.");
        stack.Push("B");
        Console.WriteLine("Pushing 'C' to stack.");
        stack.Push("C");

        Console.WriteLine("\nPeeking at the top of the stack:");
        Console.WriteLine("Expected element when doing Peek(): 'C'.");
        Console.WriteLine($"Peek: {stack.Peek()}");

        // These three Pop()s are guaranteed because we Pushed 3 elements:
        Console.WriteLine("\nPop() expected order: 'C', 'B', 'A'.");
        Console.WriteLine($"Pop: {stack.Pop()}");
        Console.WriteLine($"Pop: {stack.Pop()}");
        Console.WriteLine($"Pop: {stack.Pop()}");

        // This Peek() we KNOW will fail because there aren't any more elements on the stack
        try
        {
            Console.WriteLine("\nAttempting to Peek() on an empty stack:");
            Console.WriteLine($"Peek: {stack.Peek()}");
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Expected Exception: 'InvalidOperationException - Stack is Empty'.");
            Console.WriteLine($"Exception caught: {e.Message}");
        }
        
        // This Pop() we KNOW will fail because there aren't any more elements on the stack
        try
        {
            Console.WriteLine("\nAttempting to Pop() from an empty stack:");
            Console.WriteLine($"Pop: {stack.Pop()}");
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Expected Exception: 'InvalidOperationException - Stack is Empty'.");
            Console.WriteLine($"Exception caught: {e.Message}");
        }
    }
}