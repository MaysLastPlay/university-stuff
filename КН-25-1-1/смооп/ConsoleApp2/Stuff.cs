using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.VisualBasic;
namespace LabApp
{
    internal class Stuff
    {
        public static double Value()
        {

            double wa;
            while (!double.TryParse(Console.ReadLine(), out wa))
            {
                Console.WriteLine("You wrote something wrong, try again:");
            }

            Console.WriteLine("You're good to go!");
            return wa;
        }
        public static void MyTask1()
        {
            double x = 0;
            double y = 0;
            double z = 0;
            double w;
            double f;
            double s;

            Console.WriteLine("Write x:");
            x = Value();
            Console.WriteLine("Write y:");
            y = Value();
            Console.WriteLine("Write z:");
            z = Value();

            f = Math.Pow(Math.Abs(Math.Cos(x) - Math.Cos(y)), (1 + 2 * Math.Pow(Math.Sin(y), 2)));
            s = (1 + z + Math.Pow(z, 2) / 2 + Math.Pow(z, 3) / 3 + Math.Pow(z, 4) / 4);
            w = f * s;
            Console.WriteLine($"result = {w}");
        }
        public static void MyTask3()
        {
            int question = 1;
            int score = 0;
            double correctAnswer = 0;
            Console.WriteLine("Дай відповіді на наступні питання:");

            for (question = 1; question <= 7; question++)
            {
                Console.Clear();
                switch (question)
                {
                    case 1:
                        Console.WriteLine("Професор ліг спати о 8 годині, а встав о 9 годині. Скільки годин він спав?");
                        correctAnswer = 1;
                        break;
                    case 2:
                        Console.WriteLine("На двох руках десять пальців. Скільки пальців на 10 руках?");
                        correctAnswer = 50;
                        break;
                    case 3:
                        Console.WriteLine("Скільки цифр у дюжині?");
                        correctAnswer = 2;
                        break;
                    case 4:
                        Console.WriteLine("Скільки потрібно зробити розпилів, щоб розпиляти колоду на 12 частин?");
                        correctAnswer = 11;
                        break;
                    case 5:
                        Console.WriteLine("Лікар зробив три уколи в інтервалі 30 хвилин. Скільки часу він витратив?");
                        correctAnswer = 30;
                        break;
                    case 6:
                        Console.WriteLine("Скільки цифр 9 в інтервалі 1-100?");
                        correctAnswer = 20;
                        break;
                    case 7:
                        Console.WriteLine("Скільки місяців у році мають 28 днів?");
                        correctAnswer = 12;
                        break;
                }
                Console.Write("\nВідповідь: ");
                double userAnswer = Value();
                if (userAnswer == correctAnswer)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Відповідь правильна.");
                    Console.ResetColor();
                    score++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Неправильно. Правильна відповідь: {correctAnswer}");
                    Console.ResetColor();
                }
                Console.ReadKey();
            }

            switch (score)
            {
                case 0:
                case 1:
                case 2:
                    Console.WriteLine("Вам треба відпочити!");
                    break;
                case 3:
                    Console.WriteLine("Здібності нижче середнього");
                    break;
                case 4:
                    Console.WriteLine("Здібності середні");
                    break;
                case 5:
                    Console.WriteLine("Нормальний");
                    break;
                case 6:
                    Console.WriteLine("Ерудит");
                    break;
                case 7:
                    Console.WriteLine("Геній");
                    break;
            }
        }
        public static void MyTask5()
        {
            const double PayPer100Lines = 150.0;
            const double Penalty = 20.0;

            Console.WriteLine("1. Скільки рядків коду написати для бажаного доходу\n2. Скільки разів можна запізнитися\n3. Кількість рядків коду і кількість запізнень та виплата\nВиберіть пункт: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Потрібно ввести числа 1-3.");
                return;
            }

            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введіть бажаний дохід: ");
                    double desiredIncome = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введіть кількість майбутніх запізнень: ");
                    int lates1 = int.Parse(Console.ReadLine());

                    double totalPenalty = (lates1 / 3) * Penalty;
                    double totalToEarn = desiredIncome + totalPenalty;

                    double linesNeeded = Math.Ceiling((totalToEarn / PayPer100Lines) * 100);
                    Console.WriteLine($"\nВасі потрібно написати: {linesNeeded} рядків коду.");
                    break;

                case 2:
                    Console.WriteLine("Введіть кількість написаних рядків: ");
                    int lines2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введіть мінімально бажану зарплату: ");
                    double desiredSalary2 = double.Parse(Console.ReadLine());

                    double earned2 = (lines2 / 100.0) * PayPer100Lines;
                    double penaltyBudget = earned2 - desiredSalary2;

                    if (penaltyBudget < 0)
                    {
                        Console.WriteLine("\nНавіть без запізнень Вася не заробить таку суму.");
                    }
                    else
                    {
                        int maxPenalties = (int)(penaltyBudget / Penalty);
                        int maxLates = (maxPenalties * 3) + 2;
                        Console.WriteLine($"\nВася може запізнитися до {maxLates} разів.");
                    }
                    break;

                case 3:
                    Console.WriteLine("Введіть кількість рядків коду: ");
                    int lines3 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введіть кількість запізнень: ");
                    int lates3 = int.Parse(Console.ReadLine());

                    double earned3 = (lines3 / 100.0) * PayPer100Lines;
                    double penaltyTotal3 = (lates3 / 3) * Penalty;
                    double finalSalary = earned3 - penaltyTotal3;

                    if (finalSalary <= 0)
                        Console.WriteLine("\nВася сьогодні працює за їжу (зарплата 0 або менше).");
                    else
                        Console.WriteLine($"\nВасі заплатять: {finalSalary}$");
                    break;

                default:
                    Console.WriteLine("Невірний пункт меню.");
                    break;
            }
            Console.ReadKey();
        }

        public static void MyTask6()
        {
            Console.WriteLine("Введіть число від 1 до 100: ");

            if (double.TryParse(Console.ReadLine(), out double number))
            {
                if (number < 1 || number > 100)
                {
                    Console.WriteLine("Помилка: число поза діапазоном 1-100.");
                    return;
                }

                if (number % 3 == 0 && number % 5 == 0)
                {
                    Console.WriteLine("Fizz Buzz");
                    return;
                }
                if (number % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                    return;
                }
                if (number % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }

                Console.WriteLine(number);
                return;
            }
            Console.WriteLine("Це не число.");
        }
 
        public static void MyTask7()
        {
            int day, month, year;
            Console.WriteLine("Введіть день: ");
            day = int.Parse(Console.ReadLine());

            Console.WriteLine("Введіть місяць: ");
            month = int.Parse(Console.ReadLine());

            Console.WriteLine("Введіть рік: ");
            year = int.Parse(Console.ReadLine());

            DateTime date = new DateTime(year, month, day);

            string dayOfWeek = date.DayOfWeek.ToString();

            string season = date.Month switch
            {
                12 or 1 or 2 => "Winter",
                3 or 4 or 5 => "Spring",
                6 or 7 or 8 => "Summer",
                9 or 10 or 11 => "Autumn",
                _ => "Unknown"
            };

            Console.WriteLine($"{season} {dayOfWeek}");
        }
    }
}