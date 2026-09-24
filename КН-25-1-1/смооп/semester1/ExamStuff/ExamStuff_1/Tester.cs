using System;
using System.Collections.Generic;
using System.Text;
using ExamStuff_1.interfaces;

namespace ExamStuff_1
{
    internal class Tester : IFoo, IBar
    {
        void IFoo.Execute()
        {
            Console.WriteLine("IFoo Executes");
        }

        void IBar.Execute()
        {
            Console.WriteLine("IBar Executes");
        }
    }
}
