namespace Task4_GraphAndBFS.Helpers;

internal static class FlowHelpers
{
    /// <summary>
    /// Adds a Pause for the user in order to make the output information
    /// easier to read before the program moves on.
    /// <remarks>Press any key to go back to the menu.</remarks>
    /// </summary>
    internal static void Pause()
    {
        Console.Write("\nPress any key to go back to the menu.\n");
        var key = Console.ReadKey(intercept: true);
    }
}