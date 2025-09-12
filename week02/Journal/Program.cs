using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save to file");
            Console.WriteLine("4. Load from file");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Entry e = new Entry();
                    e._date = DateTime.Now.ToShortDateString();
                    e._promptText = prompt;
                    e._entryText = response;

                    journal.AddEntry(e);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    journal.SaveToFile(Console.ReadLine());
                    Console.WriteLine("Journal saved.");
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    journal.LoadFromFile(Console.ReadLine());
                    Console.WriteLine("Journal loaded.");
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}