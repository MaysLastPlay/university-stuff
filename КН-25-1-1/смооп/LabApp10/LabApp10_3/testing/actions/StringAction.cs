using System;
using System.Collections.Generic;
using System.Text;
using LabApp10_3.things;

namespace LabApp10_3.testing.actions
{
    internal class StringAction
    {
        public static void Run()
        {
            StringThings TextTest = new StringThings();
            string text = "I'm A-Train, I am the fastest [redacted] man alive!";
            string[] words = { "fast", "alive", "hello", "redacted" };
            Console.WriteLine($"Text: {text}\nString:");
            foreach (string word in words)
            {
                bool contains = TextTest.containsWord(text, word);
                Console.WriteLine($"Does the text contain the word? {contains}");
            }
            Console.ReadKey();
        }
    }
}
