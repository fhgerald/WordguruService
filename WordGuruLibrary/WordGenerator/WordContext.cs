using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordGuruLibrary.WordGenerator
{
    public class WordContext
    {
        private static readonly HashSet<Word> WordHashSet;
        private readonly Random _random;

        static WordContext()
        {
            WordHashSet = new HashSet<Word>();
            Read();
        }

        public WordContext()
        {
            _random = new Random();
        }

        public IEnumerable<string> GetWordWithLetters(IEnumerable<char> letters)
        {
            var letterArray = letters.Select(char.ToLower).ToArray();
            var result = WordHashSet.Where(x => x.Value.Length <= letterArray.Length);

            List<string> wordList = new List<string>();

            foreach (var word in result)
            {
                if (word.IsArrayEqual(letterArray))
                {
                    wordList.Add(word.Value);
                }
            }

            return wordList.OrderBy(x => x.Length).ThenBy(x => x);
        }

        public IEnumerable<string> GetRandom(int letterCount)
        {
            var result = WordHashSet.Where(x => x.Value.Length == letterCount);
            if (result == null)
            {
                throw new InvalidOperationException($"No words with {letterCount} letters");
            }
            var index = _random.Next(0, result.Count() - 1);
            var word = result.ElementAt(index);

            return GetWordWithLetters(word.Value.ToCharArray());
        }

        private static void Read()
        {
            bool isFirstLineHandled = false;
            using (var reader = File.OpenRead(Path.Combine(Internal.AssemblyDirectory, "Wordlist15.txt")))
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
                    if (!WordHashSet.Contains(wordItem))
                    {
                        WordHashSet.Add(wordItem);
                    }
                }
            }
        }
    }
}

