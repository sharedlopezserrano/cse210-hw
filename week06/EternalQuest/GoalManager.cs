using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int totalPoints = 0;
    private int xp = 0;
    private int level = 1;

    public void Run()
    {
        string choice = "";
        while (choice != "6")
        {
            // Mostrar progreso de XP y nivel encima del menú
            Console.WriteLine($"\nNivel: {level} | XP: {xp}/50\n");

            Console.WriteLine($"You have {totalPoints} Points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit\n");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string input;
        while (true)
        {
            Console.Write("Which type of goal would you like to create? ");
            input = Console.ReadLine();
            if (input == "1" || input == "2" || input == "3")
                break;
            Console.WriteLine("Invalid input. Please select 1, 2, or 3.");
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (input)
        {
            case "1": goals.Add(new SimpleGoal(name, description, points)); break;
            case "2": goals.Add(new EternalGoal(name, description, points)); break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, description, points, targetCount, bonus));
                break;
        }
    }

    private void ListGoals()
    {
        Console.WriteLine();
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
    }

    private void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(totalPoints);
            writer.WriteLine(xp);
            writer.WriteLine(level);
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    private void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            totalPoints = int.Parse(lines[0]);
            xp = lines.Length > 1 ? int.Parse(lines[1]) : 0;
            level = lines.Length > 2 ? int.Parse(lines[2]) : 1;
            goals.Clear();
            for (int i = 3; i < lines.Length; i++)
            {
                Goal goal = Goal.Deserialize(lines[i]);
                if (goal != null) goals.Add(goal);
            }
            Console.WriteLine("Goals loaded.");
        }
    }

    private void RecordEvent()
    {
        ListGoals();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < goals.Count)
        {
            int earned = goals[index].RecordEvent();
            totalPoints += earned;

            // Sistema de XP y nivel
            int xpEarned = 10;
            xp += xpEarned;
            bool leveledUp = false;
            while (xp >= 50)
            {
                xp -= 50;
                level++;
                leveledUp = true;
            }
            Console.WriteLine($"You earned {earned} points and {xpEarned} XP!");
            if (leveledUp)
            {
                Console.WriteLine($"¡Felicidades! Has subido al nivel {level}.");
            }
        }
    }
}
