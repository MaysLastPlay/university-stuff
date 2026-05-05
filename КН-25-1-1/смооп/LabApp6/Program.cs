using LabApp6;
using LabApp6.objects;
using LabApp6.enums;
using System.Xml.Serialization;

Shop shop1 = new Shop("Tech Store", new DateTime(2020, 5, 15), new Product[]
{
    new Product("Laptop", new Person("Alice", "Smith", new DateTime(1990, 3, 25)), 999.99m),
    new Product("Smartphone", new Person("Bob", "Johnson", new DateTime(1985, 7, 10)), 499.99m)
}, ProductCategory.Electronics);

Shop shop2 = new Shop("Book Haven", new DateTime(2018, 9, 1), new Product[]
{
    new Product("C# Programming", new Person("Charlie", "Brown", new DateTime(1995, 12, 5)), 29.99m),
    new Product("Data Structures", new Person("Diana", "Green", new DateTime(1988, 4, 20)), 39.99m)
}, ProductCategory.Books);

Console.WriteLine($"Shop: {shop1}");
Console.WriteLine($"Shop: {shop2}");
