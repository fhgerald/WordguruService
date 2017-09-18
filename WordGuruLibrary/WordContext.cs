using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordGuruLibrary
{
  public class WordContext
  {
    private readonly HashSet<Word> _wordHashSet;

    public WordContext()
    {
      _wordHashSet = new HashSet<Word>();
    }

    public IEnumerable<string> GetWordWithLetters(IEnumerable<char> letters)
    {
      var letterArray = letters.Select(char.ToLower).ToArray();
      var result = _wordHashSet.Where(x => x.Value.Length <= letterArray.Length);

      List<string> wordList = new List<string>();

      foreach (var word in result)
      {
        if (word.IsArrayEqual(letterArray))
        {
          wordList.Add(word.Value);
        }
      }

      return wordList.OrderBy(x=> x.Length).ThenBy(x=> x);
    }

    public void Read()
    {
      bool isFirstLineHandled = false;
      using (var reader = File.OpenRead("de_DE_frami.dic"))
      {
        TextReader textReader = new StreamReader(reader);

        string line;
        while ((line = textReader.ReadLine()) != null)
        {
          if (!isFirstLineHandled)
          {
            isFirstLineHandled = true;
            continue;
          }

          if (line.StartsWith("#"))
          {
            continue;
          }

          if (string.IsNullOrWhiteSpace(line))
          {
            continue;
          }

          var slashPos = line.IndexOf("/", StringComparison.Ordinal);
          var word = line.Trim();
          if (slashPos >= 0)
          {
            word = line.Substring(0, slashPos).Trim();
          }

          if (word.Length == 1)
          {
            continue;
          }

          var wordItem = new Word(word);
          if (!_wordHashSet.Contains(wordItem))
          {
            _wordHashSet.Add(wordItem);
          }
        }
      }
    }
  }
}

