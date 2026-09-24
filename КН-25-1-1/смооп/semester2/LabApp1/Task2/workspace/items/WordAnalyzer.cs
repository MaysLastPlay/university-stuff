using System;
using System.Collections.Generic;
using System.Text;

namespace Task2.workspace.items
{
    internal class WordAnalyzer
    {
        public Dictionary<string, int> wordCount { get; } = new Dictionary<string, int>();
        public void ProcessLines(string filePath)
        {
            wordCount.Clear();
            var lines = FileManager.ReadFileLines(filePath);
            foreach (var line in lines)
            {
                var words = line.Split(new[] { ' ', '\t', '.', ',', ';', ':', '!', '?', '(', ')', '[', ']', '{', '}', '"', '\'' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var rawWord in words)
                {
                    var word = rawWord.ToLower();

                    if (wordCount.ContainsKey(word))
                    {
                        wordCount[word]++;
                    }
                    else
                    {
                        wordCount[word] = 1;
                    }
                }
            }
        }
    }
}
