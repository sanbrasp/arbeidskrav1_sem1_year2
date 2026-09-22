namespace Task3_DivideAndConquer.Helpers;

// Imported from Libray project.

internal static class InputHelpers
{
    /// <summary>
    /// Reads user input from the console and attempts to parse it as a non-negative integer.
    /// Continues prompting until a valid value is entered.
    /// </summary>
    /// <param name="prompt">The message displayed to the user.</param>
    /// <returns>A non-negative integer entered by the user.</returns>
    private static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? s = Console.ReadLine();

            if (int.TryParse(s, out var value) && value >= 0)
                return value;

            Console.WriteLine("Invalid input.");
        }
    }
    
    /// <summary>
    /// Reads a menu choice from the console and ensures the value falls within the specified range.
    /// Continues prompting until a valid choice is entered.
    /// </summary>
    /// <param name="prompt">The message displayed to the user.</param>
    /// <param name="min">The minimum allowed menu value.</param>
    /// <param name="max">The maximum allowed menu value.</param>
    /// <returns>An integer within the specified range.</returns>
    internal static int ReadMenuChoice(string prompt, int min, int max)
    {
        while (true)
        {
            int value = ReadInt(prompt);

            if (value >= min && value <= max)
                return value;

            Console.WriteLine($"Invalid choice. Enter a number between {min} and {max}.");
        }
    }
}
