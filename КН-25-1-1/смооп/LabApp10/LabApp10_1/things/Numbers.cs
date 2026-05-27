using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp10_1.things
{
    internal class Numbers
    {
        public Predicate<int> PrimeNum => curNumber =>
        {
            if (curNumber < 2) return false;
            for (int i = 2; i <= Math.Sqrt(curNumber); i++)
            {
                if (curNumber % i == 0) return false;
            }
            return true;
        };
        public Predicate<int> FibonacciNum => curNumber =>
        {
            int a = 0, b = 1;
            while (b < curNumber)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return b == curNumber || a == curNumber;
        };
    }
}
