using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp10_3.things
{
    internal class ArrayThings
    {
        public Func<int[], int> SevenMultipl => array => array.Count(x => x % 7 == 0) > 0 ? 1 : 0;

        public Func<int[], int> PositiveNumbers => array => array.Count(x => x > 0);
    }
}
