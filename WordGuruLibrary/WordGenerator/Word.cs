using System;
using System.Collections.Generic;
using System.Linq;

namespace WordGuruLibrary.WordGenerator
{
  internal class Word : IComparable
  {
    private readonly Dictionary<char, int> _description;

    internal Word(string word)
    {
      Value = word;
      _description = new Dictionary<char, int>();
      _description = word.ToLower().ToCharArray().GroupBy(x => x).ToDictionary(k => k.Key, v => v.Count());
    }

    public string Value { get; }

    public bool IsArrayEqual(char[] array)
    {
      var compareTo = array.GroupBy(x => x).ToDictionary(k => k.Key, v => v.Count());
      var result = _description.Except(compareTo);
      return !result.Any();
    }


    public int CompareTo(object obj)
    {
      if (!(obj is string))
      {
        return -1;
      }

      var compareString = (string) obj;
      return string.Compare(Value, compareString, StringComparison.OrdinalIgnoreCase);
    }
  }
}
