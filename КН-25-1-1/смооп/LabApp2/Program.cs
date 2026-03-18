namespace LabApp2
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
                if (int.TryParse(Console.ReadLine(), out task))
                {
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
                        case 0:
                            Console.WriteLine("Відмова від виконання.");
                            break;
                        default:
                            Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                            break;
                    }
                    if (task != 0)
                    {
                        Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися до меню...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    if (task == 0)
                    {
                        Console.WriteLine("Вихід з програми. До побачення!");
                    }
                    else
                    {
                        Console.WriteLine("Невірний ввід. Введіть число від 0 до 5.");
                        task = -1;
                    }
                }
            } while (task != 0);
        }
    }
}
