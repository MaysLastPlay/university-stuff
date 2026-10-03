using System;
using System.Collections.Generic;
using System.Linq;
using Task1.models;

namespace Task1.services;

public class FirmService
{
    private readonly List<Firm> _firms =
    [
        new("Food Express", DateTime.Now.AddYears(-3), "Marketing", new Person("John", "White", new(1980, 5, 12), "London", "+441"), 150, "London, Baker St. 10"),
        new("Tech Innovate", DateTime.Now.AddMonths(-3), "IT", new Person("Alan", "Turing", new(1975, 6, 23), "Kyiv", "+380"), 50, "Kyiv, Khreshchatyk 1"),
        new("White Sea Food", DateTime.Now.AddYears(-5), "Food", new Person("Robert", "Black", new(1968, 11, 4), "London", "+442"), 280, "London, River Rd. 4"),
        new("Global Marketing", DateTime.Now.AddDays(-200), "Marketing", new Person("Sarah", "White", new(1990, 8, 19), "Manchester", "+443"), 350, "Manchester, High St. 12"),
        new("FastFood Delivery", DateTime.Now.AddDays(-100), "Logistics", new Person("Mike", "Tyson", new(1966, 6, 30), "London", "+444"), 80, "London, Oxford St. 22"),
        new("DevOps Studio", DateTime.Now.AddYears(-1), "IT", new Person("Anna", "Black", new(1995, 3, 15), "Lviv", "+380"), 120, "Lviv, Bandery St. 5")
    ];

    public List<Firm> GetAll() => _firms.ToList();
    public List<Firm> GetByNameFood() => _firms.Where(f => f.Name.Contains("Food", StringComparison.OrdinalIgnoreCase)).ToList();
    public List<Firm> GetByProfileMarketing() => _firms.Where(f => f.businessProfile.Equals("Marketing", StringComparison.OrdinalIgnoreCase)).ToList();
    public List<Firm> GetByProfileMarketingOrIT() => _firms.Where(f => f.businessProfile is "Marketing" or "IT").ToList();

    public List<Firm> GetWithEmployeesMoreThan(int count) => _firms.Where(f => f.EmployeesCount > count).ToList();
    public List<Firm> GetWithEmployeesBetween(int min, int max) => _firms.Where(f => f.EmployeesCount >= min && f.EmployeesCount <= max).ToList();
    public List<Firm> GetInLondon() => _firms.Where(f => f.address.Contains("London", StringComparison.OrdinalIgnoreCase)).ToList();
    public List<Firm> GetByDirectorLastName(string lastName) => _firms.Where(f => f.Director.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)).ToList();
    public List<Firm> GetOlderThanYears(int years) => _firms.Where(f => f.creationDate <= DateTime.Now.AddYears(-years)).ToList();
    public List<Firm> GetOlderThanDays(int days) => _firms.Where(f => (DateTime.Now - f.creationDate).TotalDays > days).ToList();
    public List<Firm> GetWithDirectorBlackAndNameWhite() =>
        _firms.Where(f => f.Director.LastName == "Black" && f.Name.Contains("White", StringComparison.OrdinalIgnoreCase)).ToList();
}