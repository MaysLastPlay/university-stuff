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
            Console.WriteLine("Date Stuff:");
            CurrentDate.curDate();
            CurrentDate.curDay();
            CurrentDate.curTime();
            Console.ReadKey();
        }
    }
}
