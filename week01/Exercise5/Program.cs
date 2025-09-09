using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string name = PromptUserName();
        int favorite = PromptUserNumber();

        int squared = SquareNumber(favorite);

        DisplayResult(name, squared);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out int n))
        {
            Console.Write("Please enter a valid whole number: ");
        }
        return n;
    }

    static int SquareNumber(int n)
    {
        return n * n;
    }

    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }
}