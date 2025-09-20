using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private readonly Random _rng = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        foreach (string token in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            _words.Add(new Word(token));
        }
    }

    public string GetDisplayText()
    {
        string line1 = _reference.GetDisplayText();
        string line2 = string.Join(' ', _words.Select(w => w.GetDisplayText()));
        return $"{line1}\n{line2}";
    }

    public void HideRandomWords(int count)
    {
        var visibleIndexes = _words
            .Select((w, i) => new { w, i })
            .Where(x => !x.w.IsHidden())
            .Select(x => x.i)
            .ToList();

        int n = visibleIndexes.Count;
        for (int i = 0; i < count && n > 0; i++)
        {
            int pick = _rng.Next(n);
            int wordIndex = visibleIndexes[pick];
            _words[wordIndex].Hide();

            visibleIndexes[pick] = visibleIndexes[n - 1];
            n--;
        }
    }

    public bool IsCompletelyHidden() => _words.All(w => w.IsHidden());
}