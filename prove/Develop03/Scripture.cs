using System;
using System.Collections.Generic;

public class Scripture
{
    public List<Scripture> _scripture = new List<Scripture>();
    private string _key;
    private string _text;
    public int _index;
    public string _scriptureText;

    public void LoadScriptures()
    {
        Add("matt514",
            "Ye are the light of the world. A city that is set on an hill cannot be hid. " +
            "Neither do men light a candle, and put it under a bushel, but on a candlestick; " +
            "and it giveth light unto all that are in the house. Let your light so shine before men, " +
            "that they may see your good works, and glorify your Father which is in heaven.");

        Add("alma3727",
            "Condemn me not because of mine imperfection, neither my father, because of his imperfection, " +
            "neither them who have written before him; but rather give thanks unto God that he hath made manifest " +
            "unto you our imperfections, that ye may learn to be more wise than we have been.");

        Add("ether1227",
            "And if men come unto me I will show unto them their weakness. I give unto men weakness " +
            "that they may be humble; and my grace is sufficient for all men that humble themselves before me; " +
            "for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them.");
    }

    private void Add(string key, string text)
    {
        Scripture s = new Scripture();
        s._key = key;
        s._text = text;
        _scripture.Add(s);
    }

    public void ScriptureDisplay()
    {
        foreach (Scripture item in _scripture)
        {
            item.ShowScripture();
        }
    }

    public void ShowScripture()
    {
        Console.WriteLine("\n" + _text);
    }

    public int GetRandomIndex()
    {
        Random random = new Random();
        _index = random.Next(_scripture.Count);
        return _index;
    }

    public string RandomScripture()
    {
        _index = GetRandomIndex();
        _scriptureText = _scripture[_index]._text;
        return _scriptureText;
    }

    public void HideWords() { }
    public void GetRenderedText() { }
    public void IsCompletelyHidden() { }
}
