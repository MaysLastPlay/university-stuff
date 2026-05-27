using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp8_1.lb6
{
    internal class Person : IComparable<Person>, ICloneable
    {
        private string name;
        private string surname;
        private DateTime birthDate;

        public Person(string name, string surname, DateTime birthDate)
        {
            this.name = name;
            this.surname = surname;
            this.birthDate = birthDate;
        }

        public Person()
        {
            name = "Default";
            surname = "Person";
            birthDate = new DateTime(1990, 1, 1);
        }
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

        public int BirthYear
        {
            get => birthDate.Year;
            set => birthDate = new DateTime(value, birthDate.Month, birthDate.Day);
        }

        public int GetAge()
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now < birthDate.AddYears(age))
                age--;
            return age;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname}, Birth Year: {BirthYear}, Age: {GetAge()}";
        }

        public int CompareTo(Person other)
        {
            if (other == null) return 1;
            return this.GetAge().CompareTo(other.GetAge());
        }

        public object Clone()
        {
            return new Person(this.Name, this.Surname, this.birthDate);
        }
    }
}
