using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Task2.workspace.items
{
    internal class FileManager
    {
        public static string ReadFile(string filePath)
        {
            using (var reader = new StreamReader(filePath))
                return reader.ReadToEnd();
        }

        public static async Task< List<string>> ReadFileLines(string filePath)
        {
            var lines = new List<string>();
            using var reader = new StreamReader(filePath);
            string line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                lines.Add(line);
            }
            return lines;
        }
        public static async Task Save(string filePath, Dictionary<string, int> wordCount)
        {
            using (var writer = new StreamWriter(filePath, false))
            {

                writer.WriteLine("Stats:");
                foreach (var pair in wordCount)
                {
                    writer.WriteLine($"{pair.Key}: {pair.Value}");
                }
            }
        }
    }
}
