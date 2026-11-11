using System;
using System.IO;

namespace Task1.services
{
    internal class TextAnalyzer
    {
        private const string Vowels = "aeiouAEIOUаеєиіїоуюяАЕЄИІЇОУЮЯ";

        public static string GetFile(string filePath)
        {
            while (!File.Exists(filePath))
            {
                Console.Write("Enter the path to the text file: ");
                filePath = Console.ReadLine()?.Trim().Trim('"') ?? string.Empty;
            }
            return filePath;
        }

        public TextStats AnalyzeText(string text)
        {
            int sentenceNum = 0;
            int bigLetterNum = 0;
            int smallLetterNum = 0;
            int vowelsNum = 0;
            int countNums = 0;

            foreach (char c in text)
            {
                switch (c)
                {
                    case '.' or '!' or '?':
                        sentenceNum++;
                        break;
                    case char upper when char.IsUpper(upper):
                        bigLetterNum++;
                        break;
                    case char lower when char.IsLower(lower):
                        smallLetterNum++;
                        break;
                    case char digit when char.IsDigit(digit):
                        countNums++;
                        break;
                }

                if (Vowels.Contains(c))
                {
                    vowelsNum++;
                }
            }

            return new TextStats(sentenceNum, bigLetterNum, smallLetterNum, vowelsNum, countNums);
        }
    }
}