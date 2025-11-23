using System;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }

    public int GetScore()
    {
        return _score;
    }

    public void AddPoints(int points)
    {
        _score += points;
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[goalIndex];
        goal.RecordEvent();

        int pointsEarned = goal.GetPoints();

        // Check if it's a checklist goal that just got completed for bonus
        if (goal is ChecklistGoal)
        {
            ChecklistGoal checklistGoal = (ChecklistGoal)goal;
            if (checklistGoal.IsComplete())
            {
                pointsEarned += checklistGoal.GetBonus();
                Console.WriteLine($"Congratulations! You completed the goal and earned a bonus of {checklistGoal.GetBonus()} points!");
            }
        }

        AddPoints(pointsEarned);
        Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        Console.WriteLine($"You now have {_score} points.");
    }

    public void SaveGoals(string filename)
    {
        // Add .txt if they didn't include it
        if (!filename.EndsWith(".txt"))
        {
            filename = filename + ".txt";
        }

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine($"Saved {_goals.Count} goals to {filename}");
    }

    public void LoadGoals(string filename)
    {
        // Add .txt if they didn't include it
        if (!filename.EndsWith(".txt"))
        {
            filename = filename + ".txt";
        }

        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found.");
            return;
        }

        string[] lines = System.IO.File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string goalType = parts[0];
            string[] details = parts[1].Split(",");

            if (goalType == "SimpleGoal")
            {
                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);
                bool isComplete = bool.Parse(details[3]);

                SimpleGoal goal = new SimpleGoal(name, description, points, isComplete);
                _goals.Add(goal);
            }
            else if (goalType == "EternalGoal")
            {
                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);

                EternalGoal goal = new EternalGoal(name, description, points);
                _goals.Add(goal);
            }
            else if (goalType == "ChecklistGoal")
            {
                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);
                int bonus = int.Parse(details[3]);
                int target = int.Parse(details[4]);
                int amountCompleted = int.Parse(details[5]);

                ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                _goals.Add(goal);
            }
        }

        Console.WriteLine($"Loaded {_goals.Count} goals from {filename}");
    }
}