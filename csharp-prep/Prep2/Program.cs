using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is you grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (percent <= 100 && percent >= 0)
        {
            Console.WriteLine($"Your grade is {letter}.");
        }
        else
        {
            Console.WriteLine("You did not enter a valid grade percentage.");
        }
    }
}