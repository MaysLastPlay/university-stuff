using System;
using System.Collections.Generic;
using System.Text;
using LabApp10_3.things;

namespace LabApp10_3.testing.actions
{
    internal class DateAction
    {
        public static void Run()
        {
            Console.WriteLine("Date:");
            DateTime date = DateTime.Now;
            Console.WriteLine($"Is today Programmer's Day? {DateThing.progDay(date)}");
            Console.ReadKey();
        }
    }
}
