using System;

class Program
{
    static void Main()
    {
        var journal = new Journal();
        int choice = -1;

        Console.WriteLine("**** Welcome to the Journal App ****");

        while (choice != 5)
        {
            choice = Menu();

            switch (choice)
            {
                case 1:
                    journal.NewEntry();
                    break;

                case 2:
                    journal.Display();
                    break;

                case 3:
                    Console.Write("Load file name (e.g., myjournal.txt): ");
                    journal.Load(Console.ReadLine() ?? "");
                    break;

                case 4:
                    Console.Write("Save file name (e.g., myjournal.txt): ");
                    journal.Save(Console.ReadLine() ?? "");
                    break;

                case 5:
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Please choose 1–5.");
                    break;
            }
        }
    }

    static int Menu()
    {
        Console.Write(
            "\nPlease select one of the following:\n" +
            "1. Write a new entry\n" +
            "2. Display the journal\n" +
            "3. Load the journal from a file\n" +
            "4. Save the journal to a file\n" +
            "5. Quit\n" +
            "Choice: ");

        return int.TryParse(Console.ReadLine(), out int n) ? n : -1;
    }
}
