using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp4
{
    internal class Tasks
    {
        static Random rnd = new Random();
        public static void Task1()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Введіть m, n, k через пробіл: ");
            string[] inputParams = Console.ReadLine().Split(' ');
            int m = int.Parse(inputParams[0]);
            int n = int.Parse(inputParams[1]);
            int k = int.Parse(inputParams[2]);

            double[][] A = InitMatrix(m, n);

            double[] X = new double[n];
            for (int j = 1; j <= n; j++)
            {
                X[j - 1] = (j <= k) ? k * Math.Sin(j) : Math.Cos(j);
            }

            double[] Z = Multiply(A, X, m, n);

            Console.Write("\nВектор Z: ");
            for (int i = 0; i < Z.Length; i++)
            {
                Console.Write(Z[i].ToString("F2") + "  ");
            }
            Console.WriteLine();
            SaveResults("output.txt", Z);
            CheckOrder(Z);
        }
        static double[][] InitMatrix(int m, int n)
        {
            double[][] A = new double[m][];
            Console.WriteLine("\nОберіть спосіб заповнення матриці A:\n1 - З консолі\n2 - Випадковими числами\"\n3 - З файлу ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Введіть елементи по рядку:");
                    for (int i = 0; i < m; i++)
                    {
                        A[i] = new double[n];
                        string[] rowInput = Console.ReadLine().Split(' ');
                        for (int j = 0; j < n; j++)
                        {
                            A[i][j] = double.Parse(rowInput[j]);
                        }
                    }
                    break;
                case "2":
                    Random rnd = new Random();
                    for (int i = 0; i < m; i++)
                    {
                        A[i] = new double[n];
                        for (int j = 0; j < n; j++)
                        {
                            A[i][j] = rnd.NextDouble() * 10;
                        }
                    }
                    break;
                case "3":
                    using (StreamReader sr = new StreamReader("input.txt"))
                    {
                        for (int i = 0; i < m; i++)
                        {
                            A[i] = new double[n];
                            string[] fileRow = sr.ReadLine().Split(' ');
                            for (int j = 0; j < n; j++)
                            {
                                A[i][j] = double.Parse(fileRow[j]);
                            }
                        }
                    }
                    break;
            }
            return A;
        }

        static double[] Multiply(double[][] A, double[] X, int m, int n)
        {
            double[] Z = new double[m];
            for (int i = 0; i < m; i++)
            {
                double sum = 0;
                for (int j = 0; j < n; j++)
                {
                    sum += A[i][j] * X[j];
                }
                Z[i] = sum;
            }
            return Z;
        }

        static void SaveResults(string path, double[] Z)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < Z.Length; i++)
                {
                    sw.Write(Z[i].ToString("F2"));
                    if (i < Z.Length - 1)
                    {
                        sw.Write(" ");
                    }
                }
                sw.WriteLine();
            }
            Console.WriteLine($"(Результат також збережено у файл {path})");
        }

        static void CheckOrder(double[] Z)
        {
            for (int i = 0; i < Z.Length - 1; i++)
            {
                if (Z[i] > Z[i + 1])
                {
                    Console.WriteLine($"\nПорядок порушено! Елемент: {Z[i + 1]:F2} (індекс {i + 1})");
                    return;
                }
            }
            Console.WriteLine("\nВектор впорядкований за збільшенням.");
        }
        static void Task2()
        {
            int rows = rnd.Next(3, 6);
            int[][] arr = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int cols = rnd.Next(3, 7);
                arr[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    arr[i][j] = rnd.Next(10, 100);
                }
            }

            Print(arr, "Початковий масив:");

            int maxVal = int.MinValue;
            int maxI = -1;
            int maxJ = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] > maxVal)
                    {
                        maxVal = arr[i][j];
                        maxI = i;
                        maxJ = j;
                    }
                }
            }

            if (maxI != -1 && maxJ != -1)
            {
                Console.WriteLine($"\nНайбільший елемент: {maxVal} (рядок {maxI}, стовпець {maxJ})");

                int[] tempRow = arr[0];
                arr[0] = arr[maxI];
                arr[maxI] = tempRow;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Length > maxJ && arr[i].Length > 0)
                    {
                        int tempVal = arr[i][0];
                        arr[i][0] = arr[i][maxJ];
                        arr[i][maxJ] = tempVal;
                    }
                }

                Print(arr, "\nМасив після перестановки рядків та стовпців:");
            }
            else
            {
                Console.WriteLine("\nМасив порожній, немає елементів для переміщення.");
            }
        }

        public static void Task3()
        {
            Console.WriteLine("--- Завдання 3: Перевірка на магічний квадрат ---");

            int[][] magicSquare = new int[][]
            {
            new int[] { 2, 7, 6 },
            new int[] { 9, 5, 1 },
            new int[] { 4, 3, 8 }
            };

            Print(magicSquare, "Тестовий масив 1:");
            bool isMagic1 = IsMagicSquare(magicSquare);
            Console.WriteLine(isMagic1 ? "-> Це магічний квадрат!\n" : "-> Це НЕ магічний квадрат.\n");

            int[][] notMagicSquare = new int[][]
            {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9 }
            };

            Print(notMagicSquare, "Тестовий масив 2:");
            bool isMagic2 = IsMagicSquare(notMagicSquare);
            Console.WriteLine(isMagic2 ? "-> Це магічний квадрат!" : "-> Це НЕ магічний квадрат.");
        }

        static bool IsMagicSquare(int[][] matrix)
        {
            int n = matrix.Length;

            for (int i = 0; i < n; i++)
            {
                if (matrix[i].Length != n)
                    return false;
            }

            int targetSum = 0;
            for (int j = 0; j < n; j++)
            {
                targetSum += matrix[0][j];
            }

            for (int i = 1; i < n; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < n; j++) rowSum += matrix[i][j];
                if (rowSum != targetSum) return false;
            }

            for (int j = 0; j < n; j++)
            {
                int colSum = 0;
                for (int i = 0; i < n; i++) colSum += matrix[i][j];
                if (colSum != targetSum) return false;
            }

            int diag1Sum = 0;
            int diag2Sum = 0;
            for (int i = 0; i < n; i++)
            {
                diag1Sum += matrix[i][i];
                diag2Sum += matrix[i][n - 1 - i];
            }

            if (diag1Sum != targetSum || diag2Sum != targetSum)
            {
                return false;
            }

            return true;
        }

        static void Print(int[][] arr, string title)
        {
            Console.WriteLine(title);
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
