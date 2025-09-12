using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        if (newEntry != null) _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet.");
            return;
        }
        foreach (Entry e in _entries)
        {
            e.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string file)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(_entries, options);
        File.WriteAllText(file, json);
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string json = File.ReadAllText(file);
        try
        {
            var loaded = JsonSerializer.Deserialize<List<Entry>>(json);
            _entries = loaded ?? new List<Entry>();
        }
        catch
        {
            Console.WriteLine("Could not read journal file (invalid format).");
        }
    }
//exceeds the code!
    public void Search(string term)
    {
        term = (term ?? "").Trim();
        if (term.Length == 0)
        {
            Console.WriteLine("Enter a non-empty search term.");
            return;
        }

        int matches = 0;
        foreach (var e in _entries)
        {
            if ((e._promptText?.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (e._entryText?.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0))
            {
                e.Display();
                Console.WriteLine();
                matches++;
            }
        }
        Console.WriteLine(matches == 0 ? "No matches." : $"Matches: {matches}");
    }
}