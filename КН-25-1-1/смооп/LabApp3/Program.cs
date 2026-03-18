namespace LabApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] array = new int[0];

            Console.WriteLine("1-Клавіатура, 2-файл, 3-Рандом");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Розмір N: ");
                    array = new int[int.Parse(Console.ReadLine())];
                    for (int i = 0; i < array.Length; i++) array[i] = int.Parse(Console.ReadLine());
                    break;
                case 2:
                    // Зчитування через StreamReader
                    using (StreamReader sr = new StreamReader("input.txt"))
                    {
                        string text = sr.ReadToEnd();
                        string[] parts = text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                        array = new int[parts.Length];
                        for (int i = 0; i < parts.Length; i++) array[i] = int.Parse(parts[i]);
                    }
                    break;
                case 3:
                    Console.Write("Розмір N: ");
                    array = new int[int.Parse(Console.ReadLine())];
                    for (int i = 0; i < array.Length; i++) array[i] = rnd.Next(-50, 51);
                    break;
            }

            if (array.Length < 2) return;

            int min1 = 0, min2 = 1;
            if (array[min2] < array[min1]) { min1 = 1; min2 = 0; }

            for (int i = 2; i < array.Length; i++)
            {
                if (array[i] < array[min1]) { min2 = min1; min1 = i; }
                else if (array[i] < array[min2]) { min2 = i; }
            }

            int start = Math.Min(min1, min2), end = Math.Max(min1, min2);
            int sum = 0, count = 0;

            for (int i = start + 1; i < end; i++)
            {
                sum += array[i];
                count++;
            }

            string result = $"Мінімуми: {array[min1]}, {array[min2]}\nКількість між ними: {count}\nСума: {sum}";
            Console.WriteLine("\nМасив: " + string.Join(" ", array));
            Console.WriteLine(result);

            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                sw.WriteLine("Результати розрахунку:");
                sw.WriteLine(result);
            }
            Console.WriteLine("\nРезультат також збережено в output.txt");
            Console.ReadKey();
        }
    }
}
