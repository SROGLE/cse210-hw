using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Reference reference = new Reference();
        reference.LoadReference();

        Scripture scripture = new Scripture();
        scripture.LoadScriptures();

        Word word = new Word();

        Console.WriteLine("\n**** Welcome to the Scripture Memorizer App ****\n");

        int choice = 0;
        while (choice != 3)
        {
            choice = UserChoice();

            switch (choice)
            {
                case 1:
                    reference.ReferenceDisplay();
                    break;

                case 2:
                    {
                        string script = scripture.RandomScripture();
                        string ref1 = reference.GetReference(scripture);

                        word.GetRenderedText(scripture);
                        word.GetRenderedRef(scripture);

                        while (word._hidden.Count < word._result.Length)
                        {
                            word.Show(ref1);
                            word.GetReadKey();
                        }

                        word.Show(ref1);
                        break;
                    }

                case 3:
                    Console.WriteLine("\n*** Thanks for using the Scripture Memorizer! ***\n");
                    break;

                default:
                    Console.WriteLine("\nInvalid choice, please try again.");
                    break;
            }
        }
    }

    static int UserChoice()
    {
        string menu = @"
===========================================
Please select one of the following choices:
1. Display available scripture references
2. Randomly select a scripture to memorize
Q. Quit
===========================================
What would you like to do?  ";
        Console.Write(menu);

        string input = Console.ReadLine();
        if (input != null && input.Trim().ToLower() == "q")
        {
            return 3;
        }

        int choice;
        try
        {
            choice = int.Parse(input);
        }
        catch
        {
            choice = 0;
        }
        return choice;
    }
}
// -------------------- Exceeding Requirements --------------------
// Added a small menu system that lets the user pick between 
// showing references or starting a random scripture. 
// Also included multiple scriptures from different books 
// so each session feels unique and varied.
// ---------------------------------------------------------------

