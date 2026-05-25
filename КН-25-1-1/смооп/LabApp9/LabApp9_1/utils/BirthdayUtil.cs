using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp9_1.utils
{
    internal struct BirthdayUtil
    {
     private DateOnly _birthday;
     public DateOnly DayInfo(int year, int month, int day) { return _birthday = new DateOnly(year, month, day); }
     public DayOfWeek GetDay() => _birthday.DayOfWeek;
    public DateOnly Day(int year, int month, int day) => new DateOnly(year, month, day);

    public int DaysCount()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            DateOnly BDate = new DateOnly(today.Year, _birthday.Month, _birthday.Day);
            if (BDate <= today)
                BDate = BDate.AddYears(1);
            return BDate.DayNumber - today.DayNumber;
        }
    }
}
