using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp10_1.things
{
    internal class CurrentDate
    {
        public Action curTime => () => Console.WriteLine($"Current Time is {DateTime.Now:HH:mm:ss}");
        public Action curDate => () => Console.WriteLine($"Current Date is {DateTime.Now:dd.MM.yyyy}");
        public Action curDay => () => Console.WriteLine($"Current Day is {DateTime.Now.DayOfWeek}");
    }
}
