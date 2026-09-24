using System;
using System.Collections.Generic;
using System.Text;

namespace ExamStuff_2
{
    internal class Text
    {
        public static void ShowCats(string message)
        {
            if (message == null) return;
            string[] lines = message.Split('\n');

            foreach (string line in lines)
            {
                int kittenStart = line.IndexOf('-') + 1;
                if (line.StartsWith("Kitten"))
                {
                    while (kittenStart < line.Length && line[kittenStart] == ' ')
                    {
                        kittenStart++;
                    }
                    Console.WriteLine("Found Kitten in the text.\nKitten Information:");
                    Console.WriteLine(line.Substring(kittenStart));
                    break;
                } else if (!message.Contains("Kitten"))
                {
                    Console.WriteLine("There's no kitten in text.");
                }
            }
        }
    }
}