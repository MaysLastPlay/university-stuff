using System;
using System.Collections.Generic;
using System.Text;
using LabApp10_1.things;

namespace LabApp10_1.testing.actions
{
    internal class NumbersAction
    {
        public static Random rnd = new Random();
        public static void DoNumbersTest()
        {
            Console.WriteLine("Prime Numbers:");
            for (int i = 0; i < 10; i++)
            {
                int randomNum = rnd.Next(1, 100);
                Console.WriteLine($"{randomNum} is prime: {Numbers.PrimeNum(randomNum)}");
            }
            Console.ReadKey();
            Console.WriteLine("Fibonacci Numbers:");
            for (int i = 0; i < 10; i++)
            {
                int randomNum = rnd.Next(1, 50);
                Console.WriteLine($"{randomNum} is Fibonacci: {Numbers.FibonacciNum(randomNum)}");
            }
            Console.ReadKey();
        }
    }
}
