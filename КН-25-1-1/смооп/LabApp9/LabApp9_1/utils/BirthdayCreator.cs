using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp9_1.utils
{
    internal class BirthdayCreator
    {
        public static void doBirthday()
        {
            BirthdayUtil birthday = new BirthdayUtil();
            int day = 11;
            int month = 5;
            int year = 2007;
            birthday.DayInfo(year, month, day);
            Console.WriteLine($"Date: {day}/{month}/{year}\nYour birthday is on {birthday.GetDay()}");

            int waitwhaaaa = 2028;
            Console.WriteLine($"In {waitwhaaaa} days, your birthday will be on {birthday.Day(year + waitwhaaaa, month, day).ToString("dd/MM/yyyy")}");
            int daysRemaining = birthday.DaysCount();
            Console.WriteLine($"Days remaining until your next birthday: {daysRemaining}");
        }

    }
}
