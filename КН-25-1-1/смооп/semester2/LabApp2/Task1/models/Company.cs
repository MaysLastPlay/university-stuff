using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Task1.models
{
    public record Employer(string Name, string Surname, DateTime BirthDate, decimal Salary, int WorkExperienceYears, bool hasHigherEducation)
    {
        public string FullName => $"{Name} {Surname}";
        public int Age
        {
            get
            {
                var age = DateTime.Today.Year - BirthDate.Year;
                return BirthDate.Date > DateTime.Today.AddYears(-age) ? age - 1 : age;
            }
        }
        public override string ToString() => $"{FullName} (Born: {BirthDate:dd.MM.yyyy}, Exp: {WorkExperienceYears} yrs, Salary: ${Salary:N0})";
    }
        
    public record President(string Name, string Surname, DateTime BirthDate, decimal Salary, int WorkExperienceYears, bool HasHigherEducation)
        : Employer(Name, Surname, BirthDate, Salary, WorkExperienceYears, HasHigherEducation)
    {
        public override string ToString() => $"{FullName} (Born: {BirthDate:dd.MM.yyyy}, Exp: {WorkExperienceYears} yrs, Salary: ${Salary:N0})";
    }

    public record Manager(string Name, string Surname, DateTime BirthDate, decimal Salary, int WorkExperienceYears, bool HasHigherEducation)
        : Employer(Name, Surname, BirthDate, Salary, WorkExperienceYears, HasHigherEducation)
    {
        public override string ToString() => $"{FullName} (Born: {BirthDate:dd.MM.yyyy}, Exp: {WorkExperienceYears} yrs, Salary: ${Salary:N0})";
    }

    public record Worker(string Name, string Surname, DateTime BirthDate, decimal Salary, int WorkExperienceYears, bool HasHigherEducation)
        : Employer(Name, Surname, BirthDate, Salary, WorkExperienceYears, HasHigherEducation)
    {
        public override string ToString() => $"{FullName} (Born: {BirthDate:dd.MM.yyyy}, Exp: {WorkExperienceYears} yrs, Salary: ${Salary:N0})";
    }
    public record Company(string Name, List<Employer> Employees);
}
