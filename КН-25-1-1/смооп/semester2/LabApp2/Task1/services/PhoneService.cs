using System;
using System.Collections.Generic;
using System.Linq;
using Task1.models;

namespace Task1.services;

public class PhoneService
{
    private readonly List<Phone> _phones =
    [
        new("Apple", "iPhone 13", 750, new(2021, 9, 24)),
        new("Apple", "iPhone 15 Pro", 1100, new(2023, 9, 22)),
        new("Samsung", "Galaxy S22", 650, new(2022, 2, 25)),
        new("Samsung", "Galaxy A54", 380, new(2023, 3, 24)),
        new("Xiaomi", "Redmi Note 12", 180, new(2022, 10, 27)),
        new("Xiaomi", "POCO F7", 620, new(2025, 6, 24)),
        new("Sony", "Xperia 1 V", 1200, new(2023, 7, 28)),
        new("Sony", "Xperia 10 IV", 420, new(2022, 6, 30)),
        new("Nokia", "105", 25, new(2019, 9, 1)),
        new("Google", "Pixel 7a", 480, new(2023, 5, 10))
    ];

    public int GetTotalCount() => _phones.Count;
    public int CountPriceGreaterThan(decimal threshold) => _phones.Count(p => p.Price > threshold);
    public int CountPriceBetween(decimal min, decimal max) => _phones.Count(p => p.Price >= min && p.Price <= max);
    public int CountByManufacturer(string m) => _phones.Count(p => p.Manufacturer.Equals(m, StringComparison.OrdinalIgnoreCase));

    public decimal GetMinPrice()
    {
        if (_phones.Count == 0)
        {
            throw new InvalidOperationException("The phone list is empty.");
        }
        decimal min = decimal.MaxValue;
        foreach (var phone in _phones)
        {
            if (phone.Price < min)
                min = phone.Price;

        }
        return min;
    }
    public decimal GetMaxPrice()
    {
        if (_phones.Count == 0)
        {
            throw new InvalidOperationException("The phone list is empty.");
        }
        decimal max = decimal.MinValue;
        foreach (var phone in _phones)
        {
            if (phone.Price > max)
                max = phone.Price;
        }
        return max;
    }
    public decimal GetAveragePrice()
    {
        if (_phones.Count == 0)
        {
            throw new InvalidOperationException("The phone list is empty.");
        }
        decimal sum = 0;
        foreach (var phone in _phones)
        {
            sum += phone.Price;
        }
        return sum / _phones.Count;
    }

    public Phone GetOldestPhone() => _phones.OrderBy(p => p.ReleaseDate).First();
    public Phone GetNewestPhone() => _phones.OrderByDescending(p => p.ReleaseDate).First();

    public List<Phone> GetTopExpensive(int count) => _phones.OrderByDescending(p => p.Price).Take(count).ToList();
    public List<Phone> GetTopCheapest(int count) => _phones.OrderBy(p => p.Price).Take(count).ToList();
    public List<Phone> GetTopOldest(int count) => _phones.OrderBy(p => p.ReleaseDate).Take(count).ToList();
    public List<Phone> GetTopNewest(int count) => _phones.OrderByDescending(p => p.ReleaseDate).Take(count).ToList();

    public Dictionary<string, int> GetStatsByManufacturer() =>
        _phones.GroupBy(p => p.Manufacturer).ToDictionary(g => g.Key, g => g.Count());

    public Dictionary<string, int> GetStatsByModel() =>
        _phones.GroupBy(p => p.Model).ToDictionary(g => g.Key, g => g.Count());

    public Dictionary<int, int> GetStatsByYear() =>
        _phones.GroupBy(p => p.ReleaseDate.Year).OrderByDescending(g => g.Key).ToDictionary(g => g.Key, g => g.Count());
}
