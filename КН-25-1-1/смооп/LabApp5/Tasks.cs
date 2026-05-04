using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LabApp5
{
    internal class Tasks
    {
        public static void Task1()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.Write("Введіть текст: ");
            string input = Console.ReadLine() ?? "";
            Console.Write("Введіть зсув: ");
            int shift = int.Parse(Console.ReadLine() ?? "0");

            string encrypted = CaesarCipher(input, shift);
            string decrypted = CaesarCipher(encrypted, -shift);

            Console.WriteLine($"Зашифровано: {encrypted}");
            Console.WriteLine($"Розшифровано: {decrypted}");
        }

        static string CaesarCipher(string text, int shift)
        {
            if (string.IsNullOrEmpty(text)) return text;

            StringBuilder sb = new StringBuilder();
            int alphabetSize = 33;

            for (int i = 0; i < text.Length; i++)
            {
                string s = text.Substring(i, 1);
 
                if (Regex.IsMatch(s, @"^[а-яА-ЯіІїЇєЄґҐ]$"))
                {
                    int symbolCode = Convert.ToInt32(Convert.ToChar(s));
                    bool isUpper = s.Equals(s.ToUpper(), StringComparison.CurrentCulture);
                    int offset = isUpper ? Convert.ToInt32(Convert.ToChar("А")) : Convert.ToInt32(Convert.ToChar("а"));

                    int code = (symbolCode + shift - offset) % alphabetSize;
                    if (code < 0) code += alphabetSize;

                    sb.Append(Convert.ToChar(code + offset));
                }
                else
                {
                    sb.Append(s);
                }
            }
            return sb.ToString();
        }

        public static void Task2()
        {
            string text = "";
            Console.WriteLine("Джерело:\n1 - Консоль\n2 - Тест");

            if (!int.TryParse(Console.ReadLine(), out int choice)) choice = 2;

            switch (choice)
            {
                case 1:
                    Console.Write("Введіть текст: ");
                    text = Console.ReadLine() ?? "";
                    break;
                case 2:
                    text = "Зараз затишний автобус і око побачить море";
                    break;
                default:
                    text = "Стандартний рядок";
                    break;
            }

            string[] words = text.Split(new[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Кількість слів: {words.Length}");

            StringBuilder resultBuilder = new StringBuilder();
            foreach (string word in words)
            {
                if (word.Length >= 1)
                {
                    string first = word.Substring(0, 1);
                    if (word.EndsWith(first, StringComparison.OrdinalIgnoreCase))
                    {
                        resultBuilder.Append(word).Append(" ");
                    }
                }
            }

            string resultText = resultBuilder.ToString().Trim();
            Console.WriteLine($"Слова з однаковим початком і кінцем: {resultText}");

            using (StreamWriter sw = new StreamWriter("result.txt"))
            {
                sw.WriteLine("Оригінал: " + text);
                sw.WriteLine("Результат: " + resultText);
            }
        }
    }
}