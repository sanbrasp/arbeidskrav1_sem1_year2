namespace Task3_DivideAndConquer.Helpers;

internal static class FlowHelpers
{
    internal static void Pause()
    {
        Console.Write("\nPress any key to go back to the menu.");
        var key = Console.ReadKey(intercept: true);
    }
}