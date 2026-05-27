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
            Numbers numTest = new Numbers();
            Console.WriteLine("Numbers Stuff:");
            for (int i = 0; i < 10; i++)
            {
                int randomNum = rnd.Next(1, 100);
                Console.WriteLine($"{randomNum} is prime: {numTest.PrimeNum(randomNum)}");
                Console.WriteLine($"{randomNum} is Fibonacci: {numTest.FibonacciNum(randomNum)}");
            }
            Console.ReadKey();
        }
    }
}
