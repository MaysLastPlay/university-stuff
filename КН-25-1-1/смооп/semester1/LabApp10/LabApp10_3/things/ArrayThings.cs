using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp10_3.things
{
    internal static class ArrayThings
    {
        public static Func<int[], int> SevenMultipl => array => array.Count(x => x % 7 == 0) > 0 ? 1 : 0;

        public static Func<int[], int> PositiveNumbers => array => array.Count(x => x > 0);
    }
}
