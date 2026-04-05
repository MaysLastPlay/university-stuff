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
            int[] array = new int[20];

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
                    for (int i = 0; i < array.Length; i++) array[i] = random.Next(-50, 51);
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

            Console.WriteLine("\nСписок: " + string.Join(" ", array));
            Console.WriteLine($"Мінімуми: {array[min1]}, {array[min2]}\nКількість між ними: {count}\nСума: {sum}");

            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                sw.WriteLine("Результати розрахунку:");
                sw.WriteLine($"Мінімуми: {array[min1]}, {array[min2]}\nКількість між ними: {count}\nСума: {sum}");
            }
            Console.WriteLine("\nРезультат також збережено в output.txt");
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

            Print("Вектор X", vectorX);
            Print("Вектор Z", vectorZ);

            CheckAndSaveResult(vectorZ);
        }

        static double[,] FillMatrix(int m, int n)
        {
            Console.WriteLine("\nОберіть спосіб: 1-Ручний, 2-Рандом, 3-Файл");
            int mode = int.Parse(Console.ReadLine());
            double[,] res = new double[m, n];

            switch (mode)
            {
                case 1:
                    for (int i = 0; i < m; i++)
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write($"A[{i},{j}] = ");
                            res[i, j] = double.Parse(Console.ReadLine());
                        }
                    break;
                case 2:
                    for (int i = 0; i < m; i++)
                        for (int j = 0; j < n; j++)
                            res[i, j] = Math.Round(random.NextDouble() * 10, 2);
                    break;
                case 3:
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
            return res;
        }

        static void CheckAndSaveResult(double[] z)
        {
            bool ok = true;
            int breakIdx = -1;

            for (int i = 0; i < z.Length - 1; i++)
                if (z[i] > z[i + 1]) { ok = false; breakIdx = i + 1; break; }


            using (StreamWriter sw = new StreamWriter("result.txt"))
            {
                string msg = ok ? "Впорядковано." : $"Порушено на елементі {z[breakIdx]:F2} (індекс {breakIdx})";
                Console.WriteLine($"\nРезультат: {msg}");
                sw.WriteLine($"Результат перевірки: {msg}");
            }
            Console.WriteLine("Результат також збережено у file: result.txt");
        }

        static void Print(string title, double[] arr)
        {
            Console.Write($"\n{title}: ");
            foreach (double x in arr) Console.Write($"{x:F2}  ");
            Console.WriteLine();
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
            List<int[]> emptyCells = new List<int[]>();
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    if (board[i, j] == 0) emptyCells.Add(new[] { i, j });

            if (emptyCells.Count > 0)
            {
                int[] cell = emptyCells[random.Next(emptyCells.Count)];
                board[cell[0], cell[1]] = random.Next(100) < 90 ? 2 : 4;
            }
        }

        static int ProcessLine(int[] line)
        {
            int score = 0;
            int size = line.Length;

            int[] nextLine = new int[size];
            int pos = 0;
            for (int i = 0; i < size; i++)
                if (line[i] != 0) nextLine[pos++] = line[i];
            for (int i = 0; i < size - 1; i++)
            {
                if (nextLine[i] != 0 && nextLine[i] == nextLine[i + 1])
                {
                    nextLine[i] *= 2;
                    score += nextLine[i];
                    nextLine[i + 1] = 0;
                }
            }
            for (int i = 0; i < size; i++) line[i] = 0;
            pos = 0;
            for (int i = 0; i < size; i++)
                if (nextLine[i] != 0) line[pos++] = nextLine[i];

            return score;
        }

        static int MoveLeft(int[,] board)
        {
            int totalScore = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                int[] row = new int[board.GetLength(1)];
                for (int j = 0; j < board.GetLength(1); j++) row[j] = board[i, j];
                totalScore += ProcessLine(row);
                for (int j = 0; j < board.GetLength(1); j++) board[i, j] = row[j];
            }
            return totalScore;
        }
        static int MoveRight(int[,] board)
        {
            int totalScore = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                int[] row = new int[board.GetLength(1)];
                for (int j = 0; j < board.GetLength(1); j++) row[j] = board[i, board.GetLength(1) - 1 - j];
                totalScore += ProcessLine(row);
                for (int j = 0; j < board.GetLength(1); j++) board[i, board.GetLength(1) - 1 - j] = row[j];
            }
            return totalScore;
        }
        static int MoveUp(int[,] board)
        {
            int totalScore = 0;
            for (int j = 0; j < board.GetLength(1); j++)
            {
                int[] col = new int[board.GetLength(0)];
                for (int i = 0; i < board.GetLength(0); i++) col[i] = board[i, j];
                totalScore += ProcessLine(col);
                for (int i = 0; i < board.GetLength(0); i++) board[i, j] = col[i];
            }
            return totalScore;
        }
        static int MoveDown(int[,] board)
        {
            int totalScore = 0;
            for (int j = 0; j < board.GetLength(1); j++)
            {
                int[] col = new int[board.GetLength(0)];
                for (int i = 0; i < board.GetLength(0); i++) col[i] = board[board.GetLength(0) - 1 - i, j];
                totalScore += ProcessLine(col);
                for (int i = 0; i < board.GetLength(0); i++) board[board.GetLength(0) - 1 - i, j] = col[i];
            }
            return totalScore;
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
            Console.WriteLine("Збережено!");
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