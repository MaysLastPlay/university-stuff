using System;
using System.IO;
using System.Text;

namespace Task2.services
{
    internal class TestingState
    {
        public static void RunTests()
        {
            string textPath = TextCensor.GetFile("text.txt", "main text");
            string wordsPath = TextCensor.GetFile("words.txt", "banned words");

            string text = File.ReadAllText(textPath, Encoding.UTF8);


            char[] separators = { ' ', ',', ';', '\r', '\n', '\t' };
            string[] bannedWords = File.ReadAllText(wordsPath, Encoding.UTF8).Split(separators, StringSplitOptions.RemoveEmptyEntries);

            TextCensor censor = new TextCensor();
            CensorResult result = censor.CensorText(text, bannedWords);

            Console.WriteLine("\nOg text:");
            Console.WriteLine(text);

            Console.WriteLine("\nCensored Text:");
            Console.WriteLine(result.censoredText);
            Console.WriteLine($"\nTotal words censored: {result.replacedWordsCount}");

            string outputPath = "censored_text.txt";
            File.WriteAllText(outputPath, result.censoredText, Encoding.UTF8);
            Console.WriteLine($"Saved censored text to: {Path.GetFullPath(outputPath)}");
        }
    }
}