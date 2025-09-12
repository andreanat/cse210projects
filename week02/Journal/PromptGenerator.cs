using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>();

    public PromptGenerator()
    {
        _prompts.Add("If your pet could text you right now, what would they say?");
        _prompts.Add("Describe the strangest snack combination you secretly love.");
        _prompts.Add("What song would be playing if today were a movie scene?");
        _prompts.Add("If you woke up as a cartoon character, who would you be?");
        _prompts.Add("Write about a time you laughed so hard you cried.");
        _prompts.Add("Invent a silly holiday and explain how people celebrate it.");
        _prompts.Add("If you could give the moon a new name, what would it be?");
        _prompts.Add("What’s the most random compliment you’ve ever received?");
        _prompts.Add("Describe an ordinary object as if it were a legendary treasure.");
        _prompts.Add("If you could teleport for just 5 minutes, where would you go?");
    }

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            return "";
        }

        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }
}