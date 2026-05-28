using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp10_3.things
{
    internal class DateThing
    {
        public static Func<DateTime, bool> progDay = date => date.DayOfYear == 256;
    }
}
