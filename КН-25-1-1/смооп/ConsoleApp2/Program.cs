namespace LabApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int task = -1;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            do
            {
                Console.WriteLine("Вибери Завдання:\n 1 - Завдання 1\n 2 - Завдання 2\n 3 - Завдання 3\n 4 - Завдання 4\n 5 - Завдання 5\n 0 - Вихід");
                if (!int.TryParse(Console.ReadLine(), out task))
                {
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    continue;
                }
                if (task == 6)
                {
                    Console.WriteLine("Вихід з програми. До побачення!");
                    break;
                }

                switch (task)
                {
                    case 1:
                        Console.Clear();
                        Tasks.Task1();
                        break;
                    case 2:
                        Console.Clear();
                        Tasks.Task2();
                        break;
                    case 3:
                        Console.Clear();
                        Tasks.Task3();
                        break;
                    case 4:
                        Console.Clear();
                        Tasks.Task4();
                        break;
                    case 5:
                        Console.Clear();
                        Tasks.Task5();
                        break;
                    case 6:
                        Console.WriteLine("Відмова від виконання.");
                        break;
                    default:
                        Console.WriteLine("Невірний ввід. Введіть число від 1 до 6.");
                        break;
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб продовжити...");
                Console.ReadKey();
                Console.Clear();
            } while (task != 6);
        }
    }
}
