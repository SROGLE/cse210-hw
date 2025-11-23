using System;

// Program exceeds requirements by:
// Added leveling system - users gain levels based on total points (1 level per 1000 points)
// This provides additional motivation and sense of progression through gamification

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        int choice = 0;
        while (choice != 6)
        {
            int level = manager.GetScore() / 1000;
            Console.WriteLine($"\nYou have {manager.GetScore()} points. You are level {level}.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                CreateGoal(manager);
            }
            else if (choice == 2)
            {
                ListGoals(manager);
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
            else if (choice == 3)
            {
                SaveGoals(manager);
            }
            else if (choice == 4)
            {
                LoadGoals(manager);
            }
            else if (choice == 5)
            {
                RecordEvent(manager);
            }
            else if (choice == 6)
            {
                Console.WriteLine("\nThank you for using the Eternal Quest Program!");
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Please try again.");
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        int goalType = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (goalType == 1)
        {
            SimpleGoal goal = new SimpleGoal(name, description, points);
            manager.AddGoal(goal);
        }
        else if (goalType == 2)
        {
            EternalGoal goal = new EternalGoal(name, description, points);
            manager.AddGoal(goal);
        }
        else if (goalType == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
            manager.AddGoal(goal);
        }
    }

    static void ListGoals(GoalManager manager)
    {
        List<Goal> goals = manager.GetGoals();

        if (goals.Count == 0)
        {
            Console.WriteLine("\nYou have no goals yet.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }
    }

    static void SaveGoals(GoalManager manager)
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        manager.SaveGoals(filename);
    }

    static void LoadGoals(GoalManager manager)
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        manager.LoadGoals(filename);
    }

    static void RecordEvent(GoalManager manager)
    {
        List<Goal> goals = manager.GetGoals();

        if (goals.Count == 0)
        {
            Console.WriteLine("\nYou have no goals to record.");
            return;
        }

        ListGoals(manager);
        Console.Write("Which goal did you accomplish? ");
        int goalNumber = int.Parse(Console.ReadLine());

        manager.RecordEvent(goalNumber - 1);
    }
}