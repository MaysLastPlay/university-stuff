using System;
using System.Collections.Generic;
using System.Text;
using LabApp10_3.testing.actions;

namespace LabApp10_3.testing
{
    internal class TestClass
    {
        public static void Test()
        {
            DateAction.Run();
            StringAction.Run();
            ArrayAction.Run();
        }
    }
}
