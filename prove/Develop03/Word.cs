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

    public void Hide() { _isHidden = true; }
    public void Show() { _isHidden = false; }
    public bool IsHidden() { return _isHidden; }

    public string ToDisplay()
    {
        if (!_isHidden) return _text;
        int n = _text.Length;
        string s = "";
        for (int i = 0; i < n; i++) s += "_";
        return s;
    }
}
