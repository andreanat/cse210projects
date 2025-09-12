using System;
using System.Collections.Generic;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry e in _entries)
        {
            e.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry e in _entries)
            {
                outputFile.WriteLine($"{e._date}|{e._promptText}|{e._entryText}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();
        string[] lines = System.IO.File.ReadAllLines(file);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                Entry e = new Entry();
                e._date = parts[0];
                e._promptText = parts[1];
                e._entryText = parts[2];
                _entries.Add(e);
            }
        }
    }
}