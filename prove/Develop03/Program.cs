using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        // Create a Reference using the required constructors.
        // Example A: single verse
        // Reference r = new Reference("John", 3, 16);

        // Example B: verse range (matches UML intent)
        Reference r = new Reference("Matthew", 5, 14, 16);

        string fullText =
            "Ye are the light of the world. A city that is set on an hill cannot be hid. " +
            "Neither do men light a candle, and put it under a bushel, but on a candlestick; " +
            "and it giveth light unto all that are in the house. Let your light so shine before men, " +
            "that they may see your good works, and glorify your Father which is in heaven.";

        Scripture s = new Scripture(r, fullText);

        // Show once, then progressively hide until everything is hidden or user quits.
        Console.WriteLine(s.ToDisplay());

        while (true)
        {
            Console.WriteLine();
            Console.Write("Press ENTER to hide words (or type 'quit' to end): ");
            string input = Console.ReadLine();
            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            s.HideRandom(3); // hide a few each step

            Console.Clear();
            Console.WriteLine(s.ToDisplay());

            if (s.AllHidden())
            {
                // Per requirement: program ends when the scripture is completely hidden.
                break;
            }
        }
    }
}
