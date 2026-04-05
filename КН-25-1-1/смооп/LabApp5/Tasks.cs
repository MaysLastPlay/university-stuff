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

            Console.Write("Введіть текст для шифрування: ");
            string originalText = Console.ReadLine();

            Console.Write("Введіть крок зсуву (наприклад, 3): ");
            int shift = int.Parse(Console.ReadLine());

            string encrypted = CaesarCipher(originalText, shift);
            string decrypted = CaesarCipher(encrypted, -shift);

            Console.WriteLine($"\nОригінал: {originalText}");
            Console.WriteLine($"Зашифровано: {encrypted}");
            Console.WriteLine($"Розшифровано: {decrypted}");

            using (StreamWriter sw = new StreamWriter("caesar_result.txt"))
            {
                sw.WriteLine($"Оригінал: {originalText}");
                sw.WriteLine($"Зашифровано: {encrypted}");
            }
            Console.WriteLine("\n[Результат збережено у файл caesar_result.txt]");
        }

        static string CaesarCipher(string text, int shift)
        {
            char[] buffer = text.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                if (char.IsLetter(letter))
                {
                    char offset = char.IsUpper(letter) ? 'А' : 'а';

                    int alphabetSize = 33;
                    int code = (letter + shift - offset) % alphabetSize;

                    if (code < 0)
                    {
                        code += alphabetSize;
                    }

                    buffer[i] = (char)(code + offset);
                }
            }
            return new string(buffer);
        }

        public static void Task2()
        {
            string text = "";
            Console.WriteLine("Оберіть джерело тексту:\n1 - Ввести з консолі\n2 - Використати тестовий рядок");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Введіть текст: ");
                    text = Console.ReadLine();
                    break;
                case "2":
                    text = "Завтра зранку заїде затишний автобус і око побачить море";
                    Console.WriteLine($"\nТестовий текст: {text}");
                    break;
                default:
                    Console.WriteLine("\nНевірний вибір. Програма використає тестовий текст за замовчуванням.");
                    text = "Завтра зранку заїде затишний автобус і око побачить море";
                    Console.WriteLine($"Тестовий текст: {text}");
                    break;
            }

            int count = CountSameStartEndWords(text);

            Console.WriteLine($"\nКількість слів, що починаються і закінчуються однаково: {count}");
        }

        static int CountSameStartEndWords(string text)
        {
            char[] separators = new char[] { ' ', ',', '.', '!', '?', '-', '\n', '\r' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int counter = 0;

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (word.Length > 1)
                {
                    char firstLetter = char.ToLower(word[0]);
                    char lastLetter = char.ToLower(word[word.Length - 1]);

                    if (firstLetter == lastLetter)
                    {
                        counter++;
                        Console.WriteLine($"- Знайдено слово: {word}");
                    }
                }
            }
            return counter;
        }

        public static void Task3()
        {
            Console.Write("Введіть дату: ");
            string dateInput = Console.ReadLine();

            string datePattern = @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}$";

            if (Regex.IsMatch(dateInput, datePattern))
            {
                Console.WriteLine("Формат дати ПРАВИЛЬНИЙ.");
            }
            else
            {
                Console.WriteLine("Формат дати НЕПРАВИЛЬНИЙ. Використовуйте DD/MM/YYYY.");
            }

            Console.WriteLine("\n--- Перевірка надійності пароля ---");
            Console.WriteLine("(Пароль має містити мін. 8 символів, хоча б 1 велику літеру, 1 малу літеру та 1 цифру)");
            Console.Write("Введіть пароль: ");
            string passInput = Console.ReadLine();

            string passPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";

            if (Regex.IsMatch(passInput, passPattern))
            {
                Console.WriteLine("Пароль НАДІЙНИЙ.");
            }
            else
            {
                Console.WriteLine("Пароль СЛАБКИЙ або не відповідає вимогам.");
            }
        }
    }
}
