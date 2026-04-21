namespace LabApp4
{
    internal class Tasks
    {
        static Random rnd = new Random();

        public static void Task1()
        {
            Console.Write("Введіть m n k: ");
            var cons = Console.ReadLine();

            string[] parts = cons.Split(' ');
            int m = int.Parse(parts[0]);
            int n = int.Parse(parts[1]);
            int k = int.Parse(parts[2]);

            double[][] matrixA = CreateMatrix(m, n);

            double[] vectorX = new double[n];
            for (int i = 0; i < n; i++)
            {
                int j = i + 1;

                if (j <= k)
                    vectorX[i] = k * Math.Sin(j);
                else
                    vectorX[i] = Math.Cos(j);
            }

            double[] resultZ = Multiply(matrixA, vectorX, m, n);

            Console.WriteLine("\nВектор Z:");
            foreach (var val in resultZ)
            {
                Console.Write(val.ToString("F2") + "  ");
            }

            Console.WriteLine();

            CheckAndSave(resultZ);
        }

        static double[][] CreateMatrix(int rows, int cols)
        {
            double[][] mat = new double[rows][];

            Console.WriteLine("\nСпосіб:\n1 - вручну\n2 - рандом\n3 - з файлу");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Вводьте рядки матриці:");

                        for (int row = 0; row < rows; row++)
                        {
                            mat[row] = new double[cols];
                            string[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                            if (parts.Length < cols)
                            {
                                Console.WriteLine("Недостатньо значень, спробуй ще раз...");
                                row--;
                                continue;
                            }

                            for (int col = 0; col < cols; col++)
                            {
                                mat[row][col] = double.Parse(parts[col]);
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < rows; i++)
                        {
                            mat[i] = new double[cols];

                            for (int j = 0; j < cols; j++)
                            {
                                mat[i][j] = rnd.NextDouble() * 10;
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        using (StreamReader reader = new StreamReader("input.txt"))
                        {
                            for (int i = 0; i < rows; i++)
                            {
                                mat[i] = new double[cols];

                                string line = reader.ReadLine();
                                string[] nums = line.Split(' ');

                                for (int j = 0; j < cols; j++)
                                {
                                    mat[i][j] = double.Parse(nums[j]);
                                }
                            }
                        }
                        break;
                    }
                default:
                    Console.WriteLine("заповнення 0");

                    for (int i = 0; i < rows; i++)
                    {
                        mat[i] = new double[cols];
                    }
                    break;
            }
            return mat;
        }

        static double[] Multiply(double[][] A, double[] X, int m, int n)
        {
            double[] res = new double[m];

            for (int i = 0; i < m; i++)
            {
                double tmpSum = 0;

                for (int j = 0; j < n; j++)
                {
                    tmpSum += A[i][j] * X[j];
                }

                res[i] = tmpSum;
            }
            return res;
        }


        static void CheckAndSave(double[] val)
        {
            string resultMessage = "Результат перевірки: " + "Впорядковано.";
            int problemIndex = isSortedArray(val);
            if (problemIndex > 0)
            resultMessage = "Результат перевірки: " + $"Порушено на елементі {val[problemIndex]:F2} (індекс {problemIndex})";

            using (StreamWriter writer = new StreamWriter("result.txt"))
            {
                Console.WriteLine(resultMessage);

                writer.WriteLine(resultMessage);
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

        // Створіть ступінчатий масив довільної розмірності(рядки можуть мати різну розмірність). Знайдіть найбільший елемент масиву. Перемістіть знайдений елемент у лівий верхній кут масиву шляхом перестановки рядків та стовпчиків.
        public static void Task2()
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

            var (maxI, maxJ, maxVal) = getMaxPosition(arr);
            if (maxI != -1 && maxJ != -1)
            {
                Console.WriteLine($"\nНайбільший елемент: {maxVal} (рядок {maxI}, стовпець {maxJ})");

                SwapPlaces(arr, maxI, maxJ);

                Print(arr, "\nМасив після перестановки рядків та стовпців:");
            }
            else
            {
                Console.WriteLine("\nМасив порожній, немає елементів для переміщення.");
            }
        }

        private static void SwapPlaces(int[][] arr, int maxI, int maxJ)
        {
            int firstRow = 0;

            int[] tempRow = arr[firstRow];
            arr[firstRow] = arr[maxI];
            arr[maxI] = tempRow;

            for (int i = 0; i < arr.Length; i++)
            {
                int firstCol = 0;
                if (arr[i] != null && arr[i].Length > maxJ)
                {
                    int tempVal = arr[i][firstCol];
                    arr[i][firstCol] = arr[i][maxJ];
                    arr[i][maxJ] = tempVal;
                }
            }
        }

        private static (int maxI, int maxJ, object maxVal) getMaxPosition(int[][] arr)
        {
            int maxVal = int.MinValue, maxI = -1, maxJ = -1;

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

            return (maxI, maxJ, maxVal);
        }

        // Створіть функцію, яка перевірить чи є переданий квадратний масив магічним квадратом.Магічний квадрат – квадратна таблиця, заповнена числами таким чином, що сума чисел у кожному рядку, стовпчику й на діагоналях однакова.
        public static void Task3()
        {
            int[][] firstTestSquare = new int[][]
            {
    new int[] { 2, 7, 6 },
    new int[] { 9, 5, 1 },
    new int[] { 4, 3, 8 }
            };

            Print(firstTestSquare, "Тестовий масив 1:");
            bool resultOne = IsMagicSquare(firstTestSquare);
            Console.WriteLine(resultOne ? "Це магічний квадрат!\n" : "Це НЕ магічний квадрат.\n");

            int[][] secondTestSquare = new int[][]
            {
    new int[] { 1, 2, 3 },
    new int[] { 4, 5, 6 },
    new int[] { 7, 8, 9 }
            };

            Print(secondTestSquare, "Тестовий масив 2:");
            bool resultTwo = IsMagicSquare(secondTestSquare);

            Console.WriteLine(resultTwo ? "Це магічний квадрат!" : "Це НЕ магічний квадрат."
            );
        }
        static bool IsMagicSquare(int[][] matrix)
        {
            int size = matrix.Length;
            int n = size;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i].Length != size)
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
                for (int j = 0; j < n; j++)
                {
                    rowSum += matrix[i][j];
                }

                if (rowSum != targetSum) return false;
            }

            for (int j = 0; j < n; j++)
            {
                int colSum = 0;
                for (int i = 0; i < n; i++)
                    colSum += matrix[i][j];

                if (colSum != targetSum)
                    return false;
            }

            int diagMain = 0;
            int diagSec = 0;

            for (int i = 0; i < n; i++)
            {
                diagMain += matrix[i][i];
                diagSec += matrix[i][n - 1 - i];
            }

            if (diagMain != targetSum || diagSec != targetSum)
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
