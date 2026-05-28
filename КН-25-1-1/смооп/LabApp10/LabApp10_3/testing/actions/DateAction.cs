using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp10_3.testing.actions
{
    internal class DateAction
    {
        public static void Run()
        {
            Console.WriteLine("Date:");
            DateTime date = DateTime.Now;
            Console.WriteLine($"Is today Programmer's Day? {things.DateThing.progDay(date)}");
            Console.ReadKey();
        }
    }
}
