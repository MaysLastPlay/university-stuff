using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task2.workspace.items;

namespace Task2.workspace
{
    internal class TestingState
    {
        public async Task RunTests()
        {
            var analyzer = new WordAnalyzer();
            var files = FileManager.ReadFileLines("firstFile.txt").Result;
            string? input;
            do
            {
                Console.WriteLine("\nAvailable files:");
                for (int i = 0; i < files.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {files[i]}");
                }
                Console.WriteLine("0 - Exit");

                Console.Write("\nChoice: ");
                input = Console.ReadLine();
                if (input == "0")
                {
                    break;
                }

                if (int.TryParse(input, out int ind) && ind > 0 && ind <= files.Count)
                {
                    string selectedFile = files[ind - 1];
                    await analyzer.ProcessLines(selectedFile);

                    Console.WriteLine($"\nWord count for {selectedFile}:");
                    foreach (var pair in analyzer.wordCount)
                    {
                        Console.WriteLine($"{pair.Key}: {pair.Value}");
                    }

                    await FileManager.Save("wordCount.txt", analyzer.wordCount);
                    Console.WriteLine("\nWord count saved to wordCount.txt");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            } while (input != "0");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}