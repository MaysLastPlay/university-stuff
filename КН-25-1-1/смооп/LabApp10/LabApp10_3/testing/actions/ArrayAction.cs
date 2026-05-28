using System;
using System.Collections.Generic;
using System.Text;
using LabApp10_3.things;

namespace LabApp10_3.testing.actions
{
    internal class ArrayAction
    {
        public static void Run()
        {
            Random random = new Random();
            int[] numbers = new int[10];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 100);
            }
            ArrayThings arrayThings = new ArrayThings();
            Console.WriteLine("Array:");
            Console.WriteLine($"Original array: {string.Join(", ", numbers)}");
            Console.WriteLine("Seven multiples count: " + arrayThings.SevenMultipl(numbers));
            Console.WriteLine("Positive numbers count: " + arrayThings.PositiveNumbers(numbers));
            Console.ReadKey();

        }
    }
}
