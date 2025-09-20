using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide() => _isHidden = true;
    public bool IsHidden() => _isHidden;

    public string GetDisplayText()
    {
        if (!_isHidden) return _text;

        char[] masked = new char[_text.Length];
        for (int i = 0; i < _text.Length; i++)
        {
            char c = _text[i];
            masked[i] = char.IsLetter(c) ? '_' : c;
        }
        return new string(masked);
    }
}
