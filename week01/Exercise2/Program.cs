using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int percent))
        {
            Console.WriteLine("Please enter a whole number (0–100).");
            return;
        }

        string letter;
        if (percent >= 90)      letter = "A";
        else if (percent >= 80) letter = "B";
        else if (percent >= 70) letter = "C";
        else if (percent >= 60) letter = "D";
        else                    letter = "F";

        string sign = "";
        int lastDigit = Math.Abs(percent) % 10;

        if (letter == "A")
        {

            if (lastDigit < 3) sign = "-";
        }
        else if (letter == "F")
        {
            sign = "";
        }
        else
        {
            if (lastDigit >= 7) sign = "+";
            else if (lastDigit < 3) sign = "-";
        }

        Console.WriteLine($"\nYour letter grade is: {letter}{sign}");

        if (percent >= 70) Console.WriteLine("You passed!");
        else               Console.WriteLine("Try again.");
    }
}