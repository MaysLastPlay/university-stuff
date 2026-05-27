using System;
using System.Collections.Generic;
using System.Text;
using LabApp10_1.things;

namespace LabApp10_1.testing.actions
{
    internal class DateAction
    {
        public static void DoDateTest()
        {
            CurrentDate dateTest = new CurrentDate();
            Console.WriteLine("Date Stuff:");
            dateTest.curDate();
            dateTest.curDay();
            dateTest.curTime();
            Console.ReadKey();
        }
    }
}
