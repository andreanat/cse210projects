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
            Console.WriteLine("5. Search entries (extra)");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option (1-6): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteEntry(journal, promptGen);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save (e.g., journal.json): ");
                    string saveName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(saveName))
                    {
                        journal.SaveToFile(saveName);
                        Console.WriteLine("Journal saved.");
                    }
                    break;

                case "4":
                    Console.Write("Enter filename to load (e.g., journal.json): ");
                    string loadName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(loadName))
                    {
                        journal.LoadFromFile(loadName);
                        Console.WriteLine("Journal loaded.");
                    }
                    break;

                case "5":
                    Console.Write("Search term: ");
                    string term = Console.ReadLine();
                    journal.Search(term);
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void WriteEntry(Journal journal, PromptGenerator promptGen)
    {
        string prompt = promptGen.GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Entry e = new Entry
        {
            _date = DateTime.Now.ToString("yyyy-MM-dd"),
            _promptText = prompt,
            _entryText = response ?? ""
        };

        journal.AddEntry(e);
        Console.WriteLine("Entry added.");
    }
}