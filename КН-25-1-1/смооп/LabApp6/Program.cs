using LabApp6;
using LabApp6.objects;
using LabApp6.enums;
using System.Xml.Serialization;

Person person1 = new Person("John", "Doe", new DateTime(2000, 1, 1));
DateTime openingDate = new DateTime(2020, 1, 1);
Shop shop = new Shop("Allo", openingDate, new Product[0], ProductCategory.Electronics);

Console.WriteLine(shop.ToShortString(shop.Name, shop.Category));

shop.addProduct(new Product("Laptop", person1, 1000m), new Product("Smartphone", person1, 500m));
Console.WriteLine(shop);

Shop shop1 = new Shop("Clothing Store", openingDate, new Product[0], ProductCategory.Clothing);
openingDate = new DateTime(2026, 11, 5);
person1 = new Person("Jane", "Smith", new DateTime(1995, 5, 15));
Console.WriteLine(shop1.ToShortString(shop1.Name, shop1.Category));
shop1.addProduct(new Product("T-Shirt", person1, 20m), new Product("Jeans", person1, 50m));
Console.WriteLine(shop1);

Shop shop2 = new Shop("Idk Store", openingDate, new Product[0], ProductCategory.Books);
openingDate = new DateTime(2024, 6, 1);
person1 = new Person("Alice", "Johnson", new DateTime(1985, 3, 10));
Console.WriteLine(shop2.ToShortString(shop2.Name, shop2.Category));
shop2.addProduct(new Product("Book 1", person1, 15m), new Product("Book 2", person1, 25m));
Console.WriteLine(shop2);