using System;
using System.Collections.Generic;

///Exceeds requirements:
///Randomly selects from a small library of scriptures at start.
///Hides only words that are not already hidden. Lets the user optionally choose how many words to hide each round (press Enter to use default).

class Program
{
    static void Main(string[] args)
    {
        var choices = new List<(Reference, string)>
        {
            (new Reference("John", 3, 16),
             "For God so loved the world, that he gave his only begotten Son, " +
             "that whosoever believeth in him should not perish, but have everlasting life."),
            (new Reference("Proverbs", 3, 5, 6),
             "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
             "In all thy ways acknowledge him, and he shall direct thy paths."),
            (new Reference("Mosiah", 2, 41),
             "Consider on the blessed and happy state of those that keep the commandments of God.")
        };

        var rng = new Random();
        var pick = choices[rng.Next(choices.Count)];
        var scripture = new Scripture(pick.Item1, pick.Item2);

        int defaultHideCount = 3;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write($"Press Enter to hide {defaultHideCount} words, type a number to change the amount, or type 'quit': ");

            string? input = Console.ReadLine()?.Trim().ToLower();

            if (input == "quit" || input == "q")
                break;

            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int n) && n > 0)
            {
                defaultHideCount = n;
            }

            scripture.HideRandomWords(defaultHideCount);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\n(All words hidden. Great job!)");
                break;
            }
        }
    }
}
