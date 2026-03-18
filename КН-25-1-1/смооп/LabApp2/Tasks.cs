using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp2
{
    internal class Tasks
    {
        static Random random = new Random();
        public static void Task1()
        {
            double[] angles = { 15, 30, 45, 60 };
            double x_start = 0.0;
            double x_end = 0.5;
            double dx = 0.02;

            foreach (double a in angles)
            {
                double rad = a * Math.PI / 180.0;

                Console.WriteLine($"Результати для a = {a} градусів:");
                Console.WriteLine($"{"x",10} | {"y(x)",10}");

                for (double x = x_start; x <= x_end + dx / 2; x += dx)
                {
                    double y = x * Math.Tan(rad) - Math.Pow(x, 2) / Math.Pow(Math.Cos(rad), 2);

                    Console.WriteLine($"{x,10:F4} | {y,10:F4}");
                }
            }
        }
        public static void Task2()
        {
            double[] X = { 2, 1, 0 };
            Console.WriteLine(" x |     S(x)     |     y(x)     | n");

            foreach (double x in X)
            {
                double s = 1.0, t = (x - 4) / 8.0;
                int n = 1;

                while (Math.Abs(t) >= 1e-6)
                {
                    s += t;
                    n++;
                    t *= (3 - 2.0 * n) * (x - 4) / (8.0 * n);
                }

                Console.WriteLine($"{x,2} | {s,12:F6} | {0.5 * Math.Sqrt(x),12:F6} | {n}");
            }
        }
        public static void Task3()
        {
            int score = 0, count = 0, max = 0, level;
            do
            {
                Console.Write("Оберіть рівень (1 - Легкий, 2 - Середній, 3 - Складний, 0 - Вихід): ");
                level = int.Parse(Console.ReadLine());

                switch (level)
                {
                    case 1:
                        count = 5;
                        max = 9;
                        break;
                    case 2:
                        count = 8;
                        max = 15;
                        break;
                    case 3:
                        count = 10;
                        max = 20;
                        break;
                    case 0:
                        Console.WriteLine("Відмова від виконання завдання.");
                        return;
                    default:
                        Console.WriteLine("Невірний рівень. Встановлено Легкий за замовчуванням.");
                        count = 5;
                        max = 9;
                        break;
                }

                for (int i = 1; i <= count; i++)
                {
                    int a = random.Next(2, max + 1);
                    int b = random.Next(2, max + 1);

                    Console.Write($"[{i}/{count}] {a} * {b} = ");
                    int answer = int.Parse(Console.ReadLine());

                    if (answer == a * b)
                    {
                        Console.WriteLine("Правильно!");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"Помилка! Правильна відповідь: {a * b}");
                    }
                }

                double percent = (double)score / count * 100;
                Console.WriteLine($"\n--- Ваш результат: {score}/{count} ({percent}%) ---");

                if (percent >= 90) { Console.WriteLine("Відмінно!"); return; }
                if (percent >= 70) { Console.WriteLine("Добре."); return; }
                if (percent >= 50) { Console.WriteLine("Задовільно."); return; }
                else Console.WriteLine("Варто перепочити.");
            } while (level <= 4);
        }

        public static void Task4()
        {
            Console.Write("Скільки прикладів ви хочете розв'язати? ");

            int totalExamples = int.Parse(Console.ReadLine());
            int correctAnswers = 0;

            for (int i = 1; i <= totalExamples; i++)
            {
                int num1 = random.Next(1, 51);
                int num2 = random.Next(1, 51);

                int operationType = random.Next(0, 3);
                int expectedResult = 0;
                string operationSymbol = "";

                if (operationType == 0)
                {
                    expectedResult = num1 + num2;
                    operationSymbol = "+";
                }
                else if (operationType == 1)
                {
                    expectedResult = num1 - num2;
                    operationSymbol = "-";
                }
                else if (operationType == 2)
                {
                    num1 = random.Next(2, 11);
                    num2 = random.Next(2, 11);
                    expectedResult = num1 * num2;
                    operationSymbol = "*";
                }

                Console.Write($"Приклад {i}: {num1} {operationSymbol} {num2} = ");
                int userInput = int.Parse(Console.ReadLine());

                if (userInput == expectedResult)
                {
                    Console.WriteLine("Правильно! Ваш мозок працює чудово.");
                    correctAnswers++;
                }
                else
                {
                    Console.WriteLine($"Помилка. Правильна відповідь: {expectedResult}");
                }
            }

            Console.WriteLine($"Ви розв'язали правильно {correctAnswers} з {totalExamples} прикладів.");

            double score = (double)correctAnswers / totalExamples * 100;
            if (score >= 80)
            {
                Console.WriteLine("Результат: Ви дуже розумні!");
            }
            else if (score >= 50)
            {
                Console.WriteLine("Результат: Непогано, але потрібно більше практики.");
            }
            else
            {
                Console.WriteLine("Результат: Мозок потребує більше відпочинку та тренувань.");
            }

            Console.ReadKey();
        }

        static int userTotalScore = 0;
        static int computerTotalScore = 0;
        public static void Task5() {

            if (PlayLevel("РІВЕНЬ 1", 3, 1, 11, 5, 5))
            {
                Console.Write("\nБажаєте перейти на Рівень 2? (y/n): ");
                if (Console.ReadLine().ToLower() == "y")
                {
                    PlayLevel("РІВЕНЬ 2", 2, 10, 101, 22, 10);
                }
            }

            Console.WriteLine($"\nФІНАЛЬНИЙ РАХУНОК: Ви {userTotalScore} | Комп'ютер {computerTotalScore}");
            Console.ReadKey();
        }

        static bool PlayLevel(string name, int rounds, int min, int max, int startLives, int multiplier)
        {
            Console.WriteLine($"\n=== {name} ===");
            for (int r = 1; r <= rounds; r++)
            {
                int target = random.Next(min, max);
                int lives = startLives;
                Console.WriteLine($"\n--- Раунд {r} (Число від {min} до {max - 1}) ---");

                while (lives > 0)
                {
                    Console.Write($"Життів {lives}. Ваша здогадка: ");
                    int guess = int.Parse(Console.ReadLine());

                    if (guess == target)
                    {
                        userTotalScore += lives * multiplier;
                        Console.WriteLine($"Вгадали! Очки за раунд: {lives * multiplier}");
                        break;
                    }

                    lives--;
                    if (lives <= 0)
                    {
                        computerTotalScore += startLives * multiplier;
                        Console.WriteLine("ПРОГРАШ РАУНДУ!");
                        return false;
                    }

                    Console.Write("Невірно. Підказка (-1 життя)? (y/n): ");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        lives--;
                        Console.WriteLine(target > guess ? "Загадане число БІЛЬШЕ" : "Загадане число МЕНШЕ");
                    }
                }
                Console.WriteLine($"Рахунок: Ви {userTotalScore} | Комп {computerTotalScore}");
            }
            return true;
        }
    }
}