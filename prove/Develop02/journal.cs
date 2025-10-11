using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public string Name { get; set; } = "My Journal";

    private readonly List<Entry> _entries = new List<Entry>();
    private const string SEP = "|~|"; // unlikely to appear in normal text

    // Save the entire journal to a file (one line per entry)
    public void Save(string fileName)
    {
        using var sw = new StreamWriter(fileName);
        foreach (var e in _entries)
        {
            // Title | Date | Prompt | Answer | Rating
            sw.WriteLine($"{e.Title}{SEP}{e.Date}{SEP}{e.Prompt}{SEP}{e.Answer}{SEP}{e.Rating}");
        }
        Console.WriteLine($"Saved {_entries.Count} entries to \"{fileName}\".");
    }

    // Load the entire journal from a file (replaces current list)
    public void Load(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();

        foreach (var line in File.ReadAllLines(fileName))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split(SEP, StringSplitOptions.None);
            if (parts.Length < 4) continue; // minimal fields

            var entry = new Entry
            {
                Title = parts[0],
                Date = parts[1],
                Prompt = parts[2],
                Answer = parts[3]
            };

            // Backward compatible: rating may be missing
            if (parts.Length >= 5 && int.TryParse(parts[4], out int r) && r >= 0 && r <= 5)
                entry.Rating = r;

            _entries.Add(entry);
        }

        Console.WriteLine($"Loaded {_entries.Count} entries from \"{fileName}\".");
    }

    // Show all entries
    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("(No entries yet.)");
            return;
        }

        Console.WriteLine("\n**************** Journal Entries ****************");
        foreach (var e in _entries) e.Display();
        Console.WriteLine("********************** End **********************\n");
    }

    // Return a random prompt
    public string RandomPrompt()
    {
        var prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What did I learn today?",
            "What is one thing I want to remember from today?",
            "Where did I see kindness today?",
            "What challenged me today?",
            "What went well today?"
        };

        return prompts[new Random().Next(prompts.Count)];
    }

    // Create and add a new entry (prompts user for data)
    public void NewEntry()
    {
        string prompt = RandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");

        Console.Write("Title: ");
        string title = Console.ReadLine() ?? "";

        Console.Write("Your answer:\n> ");
        string ans = Console.ReadLine() ?? "";

        // Stretch: optional rating 1–5
        int rating = 0;
        Console.Write("Rate your day 1–5 (optional, Enter to skip): ");
        string rStr = Console.ReadLine() ?? "";
        if (int.TryParse(rStr, out int r) && r >= 1 && r <= 5) rating = r;

        _entries.Add(new Entry
        {
            Title = title,
            Date = DateTime.Now.ToString("yyyy-MM-dd"),
            Prompt = prompt,
            Answer = ans,
            Rating = rating
        });

        Console.WriteLine("Entry added.");
    }
}
