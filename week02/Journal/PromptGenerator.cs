using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "If your pet could text you right now, what would they say?",
        "Describe the strangest snack combination you secretly love.",
        "What song would be playing if today were a movie scene?",
        "If you woke up as a cartoon character, who would you be?",
        "Write about a time you laughed so hard you cried.",
        "Invent a silly holiday and explain how people celebrate it.",
        "If you could give the moon a new name, what would it be?",
        "What’s the most random compliment you’ve ever received?",
        "Describe an ordinary object as if it were a legendary treasure.",
        "If you could teleport for just 5 minutes, where would you go?"
    };

    private readonly Random _rand = new Random();
    private int _lastIndex = -1;

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0) return "Write anything you like.";

        int idx;
        if (_prompts.Count == 1)
        {
            idx = 0;
        }
        else
        {
            do { idx = _rand.Next(_prompts.Count); } while (idx == _lastIndex);
        }
        _lastIndex = idx;
        return _prompts[idx];
    }
}
