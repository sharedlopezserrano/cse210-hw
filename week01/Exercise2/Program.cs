using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your Score? ");
        string scoreInput = Console.ReadLine();

        if (int.TryParse(scoreInput, out int score))
        {
            string gradeSign = "";
            int lastDigit = score % 10;

            if (lastDigit >= 7)
            {
                gradeSign = "+";
            }
            else if (lastDigit < 3)
            {
                gradeSign = "-";
            }

            if (score >= 90)
            {
                gradeSign = lastDigit < 3 ? "-" : "";
                Console.WriteLine($"Your grade is A{gradeSign}.");
            }
            else if (score >= 80)
            {
                Console.WriteLine($"Your grade is B{gradeSign}.");
            }
            else if (score >= 70)
            {
                Console.WriteLine($"Your grade is C{gradeSign}.");
            }
            else if (score >= 60)
            {
                Console.WriteLine($"Your grade is D{gradeSign}.");
            }
            else
            {
                Console.WriteLine("Your grade is F.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid score.");
        }
    }
}