using System;

class Program
{
    static void Main(string[] args)
    {

        Random random = new Random();

        while (true)
        {
            int magicNumber = random.Next(1, 101);
            int guess;
            int attempts = 0;

            do
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                attempts++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"Number of guesses: {attempts}");
                }

            } while (guess != magicNumber);

            Console.Write("Do you want to play again? (yes/no) ");
            string again = (Console.ReadLine() ?? "").Trim().ToLower();
            if (again != "yes" && again != "y") break;
            Console.WriteLine();
        }
    }
}
