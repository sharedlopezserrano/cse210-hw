using System;
using System.Collections.Generic;

// CSE 210 Shared Lopez
public class Program
{
    public static void Main()
    {
        var scriptureLibrary = new List<Scripture>
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all your ways acknowledge him, and he will make straight your paths"
            ),
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
            ),
            new Scripture(
                new Reference("Mosiah", 2, 17),
                "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God."
            ),
        };

        var random = new Random();

        while (true)
        {
            var scripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

            scripture.Reset();

            while (true)
            {
                scripture.Display();

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("All words are hidden. Program will end this scripture.");
                    break;
                }

                Console.Write("Press Enter to hide words, type 'next' for another scripture, or 'quit' to exit: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    return;
                }
                if (input.ToLower() == "next")
                {
                    break;
                }

                scripture.HideRandomWords();
            }
        }
    }
}
