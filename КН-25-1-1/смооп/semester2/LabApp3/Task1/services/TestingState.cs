using System;
using System.IO;
using System.Text;

namespace Task1.services
{
    internal class TestingState
    {
        public static void RunTests()
        {
            string textPath = TextAnalyzer.GetFile("test.txt");
            string text = File.ReadAllText(textPath, Encoding.UTF8);

            TextAnalyzer analyzer = new TextAnalyzer();
            TextStats stats = analyzer.AnalyzeText(text);

            Console.WriteLine($"Number of sentences: {stats.sentenceNum}");
            Console.WriteLine($"Number of uppercase letters: {stats.bigLetterNum}");
            Console.WriteLine($"Number of lowercase letters: {stats.smallLetterNum}");
            Console.WriteLine($"Number of vowels: {stats.vowelsNum}");
            Console.WriteLine($"Number of digits: {stats.countNums}");
        }
    }
}