using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp3
{
    internal class Tasks
    {
        static Random random = new Random();
        public static void Task1()
        {
            int[]? array = null;

            Console.WriteLine("1-Клавіатура, 2-файл, 3-Рандом");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.Write("N: ");
                        array = new int[int.Parse(Console.ReadLine())];
                        for (int i = 0; i < array.Length; i++) 
                            array[i] = int.Parse(Console.ReadLine());
                        break;
                    }
                case 2:
                    {
                        using (StreamReader sr = new StreamReader("input.txt"))
                        {
                            string text = sr.ReadToEnd();
                            string[] parts = text.Split(new[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                            array = new int[parts.Length];
                            for (int i = 0; i < parts.Length; i++) array[i] = int.Parse(parts[i]);
                        }
                        break;
                    }
                case 3:
                    {
                        Console.Write("N: ");
                        array = new int[int.Parse(Console.ReadLine())];
                        for (int i = 0; i < array.Length; i++) array[i] = random.Next(-50, 51);
                        break;
                    }
            }

            if (array.Length < 2) return;

            int min1 = 0, min2 = 1;
            if (array[min2] < array[min1]) { min1 = 1; min2 = 0; }

            for (int i = 2; i < array.Length; i++)
            {
                if (array[i] < array[min1]) 
                { 
                    min2 = min1; 
                    min1 = i;
                    continue;
                }
                if (array[i] < array[min2]) { 
                    min2 = i; 
                }
            }

            int start = min1, end = min2;
            if (start > end)
            {
                start = min2;
                end = min1;
            }

            int sum = 0, count = end - start - 1;

            for (int i = start + 1; i < end; i++)
            {
                sum += array[i];
            }

            Console.WriteLine("\nСписок: " + string.Join(" ", array));
            Console.WriteLine($"Мінімуми: {array[min1]}, {array[min2]}\nКількість між ними: {count}\nСума: {sum}");

            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                sw.WriteLine("Результати:");
                sw.WriteLine($"Мінімуми: {array[min1]}, {array[min2]}\nКількість між ними: {count}\nСума: {sum}");
            }
            Console.ReadKey();
        }
        public static void Task2()
        {
            Console.Write("Введіть m (рядки), n (стовпці), k (параметр): ");
            string[] p = Console.ReadLine().Split();
            int m = int.Parse(p[0]), n = int.Parse(p[1]), k = int.Parse(p[2]);

            double[,] matrixA = FillMatrix(m, n);

            double[] vectorX = new double[n];
            for (int j = 1; j <= n; j++)
                vectorX[j - 1] = (j <= k) ? k * Math.Sin(j) : Math.Cos(j);

            double[] vectorZ = new double[m];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    vectorZ[i] += matrixA[i, j] * vectorX[j];

            Console.WriteLine("Вектор X", vectorX);
            Console.WriteLine("Вектор Z", vectorZ);

            CheckAndSaveResult(vectorZ);
        }

        static double[,] FillMatrix(int m, int n)
        {
            Console.WriteLine("\n1-Ручний, 2-Рандом, 3-Файл");
            int mode = int.Parse(Console.ReadLine());
            double[,] res = new double[m, n];

            switch (mode)
            {
                case 1:
                    {
                        for (int i = 0; i < m; i++)
                            for (int j = 0; j < n; j++)
                            {
                                Console.Write($"A[{i},{j}] = ");
                                res[i, j] = double.Parse(Console.ReadLine());
                            }
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < m; i++)
                            for (int j = 0; j < n; j++)
                                res[i, j] = Math.Round(random.NextDouble() * 10, 2);
                        break;
                    }
                case 3:
                    {
                        using (StreamReader sr = new StreamReader("input.txt"))
                        {
                            for (int i = 0; i < m; i++)
                            {
                                string line = sr.ReadLine();
                                string[] values = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                for (int j = 0; j < n; j++)
                                    res[i, j] = double.Parse(values[j]);
                            }
                        }
                        break;
                    }
            }
            return res;
        }

        static void CheckAndSaveResult(double[] val)
        {
            string resultMessage = "Результат перевірки: " + "Впорядковано.";
           int problemIndex = isSortedArray(val);
           if (problemIndex > 0)
                    
                    resultMessage = "Результат перевірки: " + $"Порушено на елементі {val[problemIndex]:F2} (індекс {problemIndex})";


      

            using (StreamWriter writer = new StreamWriter("result.txt"))
            {
              

                Console.WriteLine( resultMessage);
               
                writer.WriteLine( resultMessage);
            }
        }

        private static int isSortedArray(double[] val)
        {
            for (int i = 0; i < val.Length - 1; i++)
            {
                if (val[i] > val[i + 1])
                {
                    return i + 1;
                }
            }
            return -1;
        }

        public static void Task3()
        {
            int size = 4;
            int[,] board = new int[size, size];

            AddRandomTile(board);
            AddRandomTile(board);

            bool running = true;
            while (running)
            {
                Console.Clear();
                PrintBoard(board);
                Console.WriteLine("\nWASD - рух, F - зберегти в файл, R - зчитати з файлу, Q - вихід");

                ConsoleKey key = Console.ReadKey(true).Key;
                int scoreInc = 0;

                switch (key)
                {
                    case ConsoleKey.W: scoreInc = MoveUp(board); break;
                    case ConsoleKey.S: scoreInc = MoveDown(board); break;
                    case ConsoleKey.A: scoreInc = MoveLeft(board); break;
                    case ConsoleKey.D: scoreInc = MoveRight(board); break;
                    case ConsoleKey.F: SaveToFile(board); continue;
                    case ConsoleKey.R: board = LoadFromFile(size); continue;
                    case ConsoleKey.Q: running = false; continue;
                    default: continue;
                }

                if (scoreInc >= 0)
                {
                    AddRandomTile(board);
                    Console.WriteLine($"\nОтримано балів: {scoreInc}");
                    System.Threading.Thread.Sleep(300);
                }
            }
        }
        static void AddRandomTile(int[,] board)
        {
            int zeros = 0;
            foreach (int v in board) if (v == 0) zeros++;
            if (zeros == 0) return;

            int i, j;
            do
            {
                i = random.Next(board.GetLength(0));
                j = random.Next(board.GetLength(1));
            } while (board[i, j] != 0);

            board[i, j] = random.Next(100) < 90 ? 2 : 4;
        }

        static int MoveLeft(int[,] board)
        {
            int score = 0;
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 1; j < board.GetLength(1); j++)
                    if (board[i, j] != 0)
                        for (int k = j; k > 0; k--)
                        {
                            if (board[i, k - 1] == 0) {
                                board[i, k - 1] = board[i, k];
                                board[i, k] = 0;
                                continue;
                            }
                            if (board[i, k - 1] == board[i, k]) {
                                board[i, k] = 0;
                                score += (board[i, k - 1] *= 2);
                            }
                            break;
                        }
            return score;
        }

        static int MoveRight(int[,] board)
        {
            int score = 0;
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = board.GetLength(1) - 2; j >= 0; j--)
                    if (board[i, j] != 0)
                        for (int k = j; k < board.GetLength(1) - 1; k++)
                        {
                            if (board[i, k + 1] == 0) {
                                board[i, k + 1] = board[i, k];
                                board[i, k] = 0;
                                continue;
                            }
                            if (board[i, k + 1] == board[i, k]) {
                                board[i, k] = 0;
                                score += (board[i, k + 1] *= 2);
                            }
                            break;
                        }
            return score;
        }

        static int MoveUp(int[,] board)
        {
            int score = 0;
            for (int j = 0; j < board.GetLength(1); j++)
                for (int i = 1; i < board.GetLength(0); i++)
                    if (board[i, j] != 0)
                        for (int k = i; k > 0; k--)
                        {
                            if (board[k - 1, j] == 0) {
                                board[k - 1, j] = board[k, j];
                                board[k, j] = 0;
                                continue;
                            }
                            if (board[k - 1, j] == board[k, j])
                            {
                                board[k, j] = 0;
                                score += (board[k - 1, j] *= 2);
                            }
                            break;
                        }
            return score;
        }

        static int MoveDown(int[,] board)
        {
            int score = 0;
            for (int j = 0; j < board.GetLength(1); j++)
                for (int i = board.GetLength(0) - 2; i >= 0; i--)
                    if (board[i, j] != 0)
                        for (int k = i; k < board.GetLength(0) - 1; k++)
                        {
                            if (board[k + 1, j] == 0) {
                                board[k + 1, j] = board[k, j];
                                board[k, j] = 0;
                                continue;
                            }
                            if (board[k + 1, j] == board[k, j]) {
                                board[k, j] = 0;
                                score += (board[k + 1, j] *= 2);
                            }
                            break;
                        }
            return score;
        }
        static void SaveToFile(int[,] board)
        {
            using (StreamWriter sw = new StreamWriter("save.txt"))
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                        sw.Write(board[i, j] + " ");
                    sw.WriteLine();
                }
            }
        }

        static int[,] LoadFromFile(int size)
        {
            int[,] res = new int[size, size];
            if (!File.Exists("save.txt")) return res;
            using (StreamReader sr = new StreamReader("save.txt"))
            {
                for (int i = 0; i < size; i++)
                {
                    string[] parts = sr.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < size; j++) res[i, j] = int.Parse(parts[j]);
                }
            }
            return res;
        }

        static void PrintBoard(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                    Console.Write((board[i, j] == 0 ? "." : board[i, j].ToString()).PadLeft(5));
                Console.WriteLine("\n");
            }
        }
    }
}