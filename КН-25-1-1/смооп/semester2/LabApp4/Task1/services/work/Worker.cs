using System;

namespace Task1.services.work
{
    [Serializable]
    public class Worker
    {
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public Worker() { }
        public Worker(string fullName, string position, decimal salary, DateTime hireDate)
        {
            FullName = fullName;
            Position = position;
            Salary = salary;
            HireDate = hireDate;
        }

        public override string ToString()
        {
            return $"Name: {FullName}, Position: {Position}, Salary: {Salary:F2} грн, Hire Date: {HireDate:dd.MM.yyyy}";
        }
    }
}