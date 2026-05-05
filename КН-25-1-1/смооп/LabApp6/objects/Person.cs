using System;

namespace LabApp6.objects
{
    internal class Person
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
    }
}
