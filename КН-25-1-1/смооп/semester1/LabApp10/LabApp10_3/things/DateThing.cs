using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp10_3.things
{
    internal static class DateThing
    {
        public static Func<DateTime, bool> progDay = date => date.DayOfYear == 256;
    }
}
