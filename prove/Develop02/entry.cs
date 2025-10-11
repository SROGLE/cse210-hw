using System;

public class Entry
{
    // Stored as simple strings per assignment spec
    public string Title { get; set; } = "";
    public string Date { get; set; } = "";   // e.g., "2025-10-11"
    public string Prompt { get; set; } = "";
    public string Answer { get; set; } = "";

    // Stretch: optional rating 1–5
    public int Rating { get; set; } = 0;

    public void Display()
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Title : {Title}");
        Console.WriteLine($"Date  : {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Entry : {Answer}");
        if (Rating > 0) Console.WriteLine($"Rating: {Rating}/5");
    }
}
