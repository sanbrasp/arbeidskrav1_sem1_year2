using Spectre.Console;

using Task2_CustomGenericDataStructure.Models;

namespace Task2_CustomGenericDataStructure;

class Program
{
    static void Main(string[] args)
    {
        var stack = new CustomStack<string>();
        
        AnsiConsole.Write(new Panel("[bold green]Demonstration of Custom Generic Stack[/]"));
        
        AnsiConsole.MarkupLine("\n[green bold]Pushing elements to the stack:[/]");
        AnsiConsole.MarkupLine("[blue]Pushing 'A' to the stack[/]");
        stack.Push("A");
        AnsiConsole.MarkupLine("[blue]Pushing 'B' to the stack[/]");
        stack.Push("B");
        AnsiConsole.MarkupLine("[blue]Pushing 'C' to the stack[/]");
        stack.Push("C");
        
        AnsiConsole.MarkupLine("\n[green bold]Peeking at the top of the stack:[/]");
        AnsiConsole.MarkupLine("[green]Expected element: 'C'.[/]");
        AnsiConsole.MarkupLine($"[blue]Peek: {stack.Peek()}[/]");
        
        // These three Pop()s are guaranteed because we Pushed 3 elements:
        AnsiConsole.MarkupLine("\n[green bold]Popping:[/]");
        AnsiConsole.MarkupLine("[green]Pop() expected order: 'C', 'B', 'A'.[/]");
        AnsiConsole.MarkupLine($"[blue]Pop: {stack.Pop()}[/]");
        AnsiConsole.MarkupLine($"[blue]Pop: {stack.Pop()}[/]");
        AnsiConsole.MarkupLine($"[blue]Pop: {stack.Pop()}[/]");
        
        // This Peek() we KNOW will fail because there aren't any more elements on the stack
        try
        {
            AnsiConsole.MarkupLine("\n[green bold]Attempting to Peek() on an empty stack:[/]");
            AnsiConsole.MarkupLine($"[blue]Peek: {stack.Peek()}[/]");
        }
        catch (InvalidOperationException e)
        {
            AnsiConsole.MarkupLine("[green]Expected Exception: 'InvalidOperationException - Stack is Empty'.[/]");
            AnsiConsole.MarkupLine($"[red]Exception caught: {e.Message}[/]");
        }
        
        // This Pop() we KNOW will fail because there aren't any more elements on the stack
        try
        {
            AnsiConsole.MarkupLine("\n[green bold]Attempting to Pop() from an empty stack:[/]");
            AnsiConsole.MarkupLine($"[blue]Pop: {stack.Pop()}[/]");
        }
        catch (InvalidOperationException e)
        {
            AnsiConsole.MarkupLine("[green]Expected Exception: 'InvalidOperationException - Stack is Empty'.[/]");
            AnsiConsole.MarkupLine($"[red]Exception caught: {e.Message}[/]");
        }
    }
}