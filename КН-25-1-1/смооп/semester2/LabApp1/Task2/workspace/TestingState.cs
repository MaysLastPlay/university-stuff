using System;
using System.Collections.Generic;
using System.Text;
using Task2.workspace.items;

namespace Task2.workspace
{
    internal class TestingState
    {
        public void RunTests()
        {
            var analyzer = new WordAnalyzer();
            var files = FileManager.ReadFileLines("firstFile.txt");

            while (true)
            {
                Console.WriteLine("\nAvailable files:");
                for (int i = 0; i < files.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {files[i]}");
                }
                Console.WriteLine("0 - Exit");

                Console.Write("\nChoice: ");
                string? input = Console.ReadLine();

                if (input == "0")
                {
                    break;
                }

                if (int.TryParse(input, out int ind) && ind > 0 && ind <= files.Count)
                {
                    string selectedFile = files[ind - 1];
                    analyzer.ProcessLines(selectedFile);

                    Console.WriteLine($"\nWord count for {selectedFile}:");
                    foreach (var pair in analyzer.wordCount)
                    {
                        Console.WriteLine($"{pair.Key}: {pair.Value}");
                    }

                    FileManager.Save("wordCount.txt", analyzer.wordCount);
                    Console.WriteLine("\nWord count saved to wordCount.txt");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}