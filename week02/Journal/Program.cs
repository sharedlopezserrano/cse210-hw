using System;
using System.Collections.Generic;

// CSE 210 Shared Lopez This is a Journal Program
public class Program
{
    private static List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What made you smile today?",
        "What challenge did you overcome today?",
        "Describe a moment you felt grateful today.",
        "What did you learn today?",
        "How did you help someone today?"
    };

    public static void Main(string[] args)
    {
        Journal journal = new Journal();
        Random rand = new Random();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = _prompts[rand.Next(_prompts.Count)];
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    Console.Write("How are you feeling now? ");
                    string feeling = Console.ReadLine();
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    journal.AddEntry(new Entry(date, prompt, $"{response}\nFeeling after: {feeling}"));
                    break;

                case "2":
                    journal.Display();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose 1-5.");
                    break;
            }

            Console.WriteLine();
        }

        Console.WriteLine("Goodbye!");
    }
}
