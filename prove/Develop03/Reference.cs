using System;
using System.Collections.Generic;

public class Reference
{
    public List<Reference> _reference = new List<Reference>();
    private string _key;
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;

    public void LoadReference()
    {
        // Different verses from the previous version
        Add("matt514", "Matthew", 5, 14, 16);
        Add("alma3727", "Alma", 37, 27, 0);
        Add("ether1227", "Ether", 12, 27, 0);
    }

    private void Add(string key, string book, int chap, int start, int end)
    {
        Reference r = new Reference();
        r._key = key;
        r._book = book;
        r._chapter = chap;
        r._verseStart = start;
        r._verseEnd = end;
        _reference.Add(r);
    }

    public void ReferenceDisplay()
    {
        foreach (Reference item in _reference)
        {
            if (item._verseEnd == 0)
                item.ReferenceOne();
            else
                item.ReferenceTwo();
        }
    }

    public string GetReference(Scripture scripture)
    {
        int index = scripture._index;
        Reference refi = _reference[index];

        if (refi._verseEnd == 0)
        {
            return "\n" + refi._book + " " + refi._chapter + ":" + refi._verseStart;
        }
        else
        {
            return "\n" + refi._book + " " + refi._chapter + ":" + refi._verseStart + "-" + refi._verseEnd;
        }
    }

    public void ReferenceOne()
    {
        Console.WriteLine("\n" + _book + " " + _chapter + ":" + _verseStart);
    }

    public void ReferenceTwo()
    {
        Console.WriteLine("\n" + _book + " " + _chapter + ":" + _verseStart + "-" + _verseEnd);
    }
}
