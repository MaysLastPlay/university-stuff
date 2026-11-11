using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Task2.services
{
    internal class TextCensor
    {
        public static string GetFile(string filePath, string fileType = "text")
        {
            while (!File.Exists(filePath))
            {
                Console.Write($"Enter the path to the {fileType} file: ");
                filePath = Console.ReadLine()?.Trim().Trim('"') ?? string.Empty;
            }
            return filePath;
        }

        public CensorResult CensorText(string text, string[] bannedWords)
        {
            string resultText = text;
            int replacedCount = 0;

            foreach (string word in bannedWords)
            {
                if (string.IsNullOrWhiteSpace(word))
                    continue;

                string cleanWord = word.Trim();
                string stars = new string('*', cleanWord.Length);

                resultText = Regex.Replace(
                    resultText,
                    Regex.Escape(cleanWord),
                    match =>
                    {
                        replacedCount++;
                        return stars;
                    },
                    RegexOptions.IgnoreCase
                );
            }

            return new CensorResult(resultText, replacedCount);
        }
    }
}
