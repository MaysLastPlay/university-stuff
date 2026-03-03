namespace LabApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Введи Завдання:");
            if (int.TryParse(Console.ReadLine(), out int choice)) {
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Stuff.MyTask1();
                        break;
                    case 2:
                        Console.Clear();
                        Stuff.MyTask3();
                        break;
                    case 3:
                        Console.Clear();
                        Stuff.MyTask5();
                        break;
                    case 4:
                        Console.Clear();
                        Stuff.MyTask6();
                        break;

                    case 5:
                        Console.Clear();
                        Stuff.MyTask7();
                        break;
                    case 6:
                        Console.WriteLine("Натисни будь-яку клавішу для завершення.");
                        break;
                    default:
                        Console.WriteLine("Invalid task number.");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
