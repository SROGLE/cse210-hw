using System;
using System.Collections.Generic;

public class Word
{
    public string _words = "";
    public string _ref = "";
    public string[] _result;
    public List<int> _hidden;

    public Word() { }

    public void GetRenderedText(Scripture scripture)
    {
        _words = scripture._scriptureText;
        _result = _words.Split(' ');
        _hidden = new List<int>();
    }

    public void GetRenderedRef(Scripture scripture) { }

    public void Show(string ref1)
    {
        _ref = ref1;
        Console.Clear();
        Console.Write("\n**** Press spacebar or enter to hide words ****");
        Console.Write("\n**** Press Q to Quit ****\n");
        Console.WriteLine(_ref);

        for (int i = 0; i < _result.Length; i++)
        {
            string word = _result[i];
            if (IsHidden(i))
            {
                Console.Write(new string('_', word.Length) + " ");
            }
            else
            {
                Console.Write(word + " ");
            }
        }
    }

    public void GetReadKey()
    {
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key == ConsoleKey.Spacebar || key.Key == ConsoleKey.Enter)
        {
            GetNewHiddenWord();
            GetNewHiddenWord();
        }
        else if (key.Key == ConsoleKey.Q)
        {
            Environment.Exit(0);
        }
    }

    private void GetNewHiddenWord()
    {
        if (_hidden.Count >= _result.Length) return;

        Random random = new Random();
        int index = random.Next(_result.Length);

        int tries = 0;
        while (IsHidden(index) && tries < 8)
        {
            index = random.Next(_result.Length);
            tries++;
        }

        if (!IsHidden(index))
            _hidden.Add(index);
        else
        {
            for (int i = 0; i < _result.Length; i++)
            {
                if (!IsHidden(i))
                {
                    _hidden.Add(i);
                    break;
                }
            }
        }
    }

    private bool IsHidden(int index)
    {
        for (int i = 0; i < _hidden.Count; i++)
        {
            if (_hidden[i] == index)
                return true;
        }
        return false;
    }
}
