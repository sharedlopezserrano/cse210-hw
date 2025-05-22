using System;

public class Program
{
    public static void Main()
    {
        var reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all your ways acknowledge him, and he will make straight your paths";
        var scripture = new Scripture(reference, text);

        while (true)
        {
            scripture.Display();

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("All words are hidden. Program will end.");
                break;
            }

            Console.Write("Press Enter to hide words or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
        }
    }
}
