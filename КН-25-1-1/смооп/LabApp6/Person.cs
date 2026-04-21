using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp6
{
    internal class Person
    {
        private string name;
        private string surname;
        private DateTime dateTime;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public DateTime DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }
    }
}
