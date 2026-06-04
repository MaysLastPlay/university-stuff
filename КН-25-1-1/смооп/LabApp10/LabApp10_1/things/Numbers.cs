using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp10_1.things
{
    internal static class Numbers
    {
        public static Predicate<int> PrimeNum => curNumber =>
        {
            if (curNumber < 2) return false;
            for (int i = 2; i <= Math.Sqrt(curNumber); i++)
            {
                if (curNumber % i == 0) return false;
            }
            return true;
        };
        public static Predicate<int> FibonacciNum => curNumber =>
        {
            if (curNumber < 0) return false;

            int a = 5 * curNumber * curNumber + 4;
            int b = 5 * curNumber * curNumber - 4;

            int numA = (int)Math.Sqrt(a);
            int numB = (int)Math.Sqrt(b);

            return (numA * numA == a) || (numB * numB == b);
        };
    }
}
