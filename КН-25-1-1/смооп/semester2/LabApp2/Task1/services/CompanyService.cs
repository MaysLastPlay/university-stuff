using System;
using System.Collections.Generic;
using System.Linq;
using Task1.models;

namespace Task1.services;

public class CompanyService
{
    private readonly Company _company = new("SoftTech",
    [
        new President("Alexander", "Koval", new(1975, 4, 15), 95000, 22, true),
        new Manager("Volodymyr", "Melnyk", new(1992, 10, 8), 45000, 8, true),
        new Manager("Iryna", "Bondar", new(1983, 3, 21), 52000, 14, true),
        new Manager("Serhii", "Tkachenko", new(1998, 10, 14), 38000, 4, false),
        new Worker("Volodymyr", "Shevchenko", new(2003, 11, 5), 24000, 2, false),
        new Worker("Dmytro", "Hrynenko", new(1989, 10, 25), 28000, 11, true),
        new Worker("Volodymyr", "Sydorenko", new(1996, 7, 19), 31000, 6, true),
        new Worker("Maksym", "Lytvyn", new(1980, 2, 12), 33000, 18, true),
        new Worker("Olena", "Kravchuk", new(1999, 10, 2), 26000, 3, true),
        new Worker("Andrii", "Pavliuk", new(1978, 6, 30), 35000, 20, false),
        new Worker("Vitalii", "Moroz", new(1986, 9, 11), 30000, 13, true)
    ]);

    public int GetEmployeesCount() => _company.Employees.Count;
    public decimal GetTotalSalaryFund() => _company.Employees.Sum(e => e.Salary);
    public Manager? GetYoungestManager() => _company.Employees.OfType<Manager>().OrderByDescending(m => m.BirthDate).FirstOrDefault();
    public Manager? GetOldestManager() => _company.Employees.OfType<Manager>().OrderBy(m => m.BirthDate).FirstOrDefault();

    public Employer? GetYoungestEducatedAmongTopExperience(int topCount = 10) =>
        _company.Employees
            .OrderByDescending(e => e.WorkExperienceYears).Take(topCount)
            .Where(e => e.hasHigherEducation)
            .OrderByDescending(e => e.BirthDate)
            .FirstOrDefault();

    public List<Employer> GetEmployeesNamedVolodymyr() =>
        _company.Employees.Where(e => e.Name.Equals("Volodymyr", StringComparison.OrdinalIgnoreCase)).ToList();

    public Employer? GetYoungestVolodymyr() =>
        GetEmployeesNamedVolodymyr().OrderByDescending(e => e.BirthDate).FirstOrDefault();

    public Dictionary<string, List<string>> GetOctoberBornGroupedByRole() =>
        _company.Employees
            .Where(e => e.BirthDate.Month == 10)
            .GroupBy(e => e.GetType().Name)
            .ToDictionary(g => g.Key, g => g.Select(e => e.Name + " " + e.Surname).ToList());
}