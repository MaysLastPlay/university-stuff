using System;
using System.Collections.Generic;
using System.Text;

namespace Idkwhatisthatttttt
{
    internal class TestingStuff
    {
        public TestingStuff() { }

        static Random rnd = new Random();

        public void Arraything(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                int wa = 0;
                for (int j = 1; j < a.GetLength(1); j++)
                    if (a[i, j] < a[i, wa]) wa = j;

                for (int j = 0; j < wa; j++)
                    a[i, j] += a[i, i];
            }
        }

       public static int[] WhatIsThat(int[] a, int day = 15)
        {
            int[] result = new int[a.Length];
            int k = 0;

            foreach (int x in a)
            {
                if (!(x % 2 == 0 && x > day))
                    result[k++] = x;
            }

            foreach (int x in a)
            {
                if (x % 2 == 0 && x > day)
                    result[k++] = x;
            }


            return result;
        }

    }
}
