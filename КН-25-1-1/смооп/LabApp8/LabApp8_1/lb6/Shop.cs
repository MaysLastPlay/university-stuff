using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LabApp8_1.interfaces;
using LabApp8_1.lb6;

namespace LabApp8_1.lb6
{
    enum ProductCategory
    {
        Electronics,
        Clothing,
        Food,
        Books,
        Furniture
    }
    internal class Shop : IFileContainer<Product>, IEnumerable
    {
        private string name;
        private DateTime openingDate;
        private Product[] products;
        private ProductCategory category;
        private bool isSaved = true;

        public Shop(string name, DateTime openingDate, Product[] products, ProductCategory category)
        {
            this.name = name;
            this.openingDate = openingDate;
            this.products = products;
            this.category = category;
            CalculateTotalCost();
        }

        public Shop() 
            {
            name = "Unnamed Shop";
            openingDate = new DateTime(2000, 1, 1);
            products = new Product[0];
            category = ProductCategory.Electronics;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Product[] Products
        {
            get { return products; }
            set { products = value; }
        }

        public DateTime OpeningDate
        {
            get { return openingDate; }
            set { openingDate = value; }
        }

        public ProductCategory Category
        {
            get { return category; }
            set { category = value; }
        }

        public double CalculateTotalCost(double totalCost = 0)
        {
            foreach (var product in products)
            {
                totalCost += (double)product.Price;
            }
            return totalCost;
        }

        public void addProduct(params Product[] products)
        {
            var newProducts = new Product[this.products.Length + products.Length];
            this.products.CopyTo(newProducts, 0);
            products.CopyTo(newProducts, this.products.Length);
            this.products = newProducts;
        }

        public int Count => products.Length;
        public bool Saved => throw new NotImplementedException();


        public bool this[ProductCategory category]
        {
            get { if (category == this.category) return true; else return false; }
        }

        public void Delete(Product element)
        {
            int index = Array.IndexOf(products, element);
            if (index == -1)
            {
                Array.Copy(products, index + 1, products, index, products.Length - index - 1);
                Array.Resize(ref products, products.Length - 1);

            }
            isSaved = false;
        }

        public void Add(Product element)
        {
            if (element == null) return;
            Product[] newProducts = new Product[products.Length + 1];
            Array.Copy(products, newProducts, products.Length);
            newProducts[products.Length] = element;
            products = newProducts;
            isSaved = false;
        }

        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= products.Length)
                    throw new IndexOutOfRangeException("Index out of range.");
                return products[index];
            }
            set
            {
                if (index < 0 || index >= products.Length)
                    throw new IndexOutOfRangeException("Index out of range.");
                if (value is Product)
                {
                    products[index] = (Product)value;
                    isSaved = false;
                }
                else
                    throw new ArgumentException("Value must be of type Product.");
            }
        }

        public void Save(string filePath)
        {
            using (var writer = new System.IO.StreamWriter(filePath))
            {
                writer.WriteLine(Name);
                writer.WriteLine(OpeningDate);
                writer.WriteLine(Category);
                foreach (var product in products)
                {
                    writer.WriteLine($"{product.Name}|{product.Price}|{product.Provider.Name}|{product.Provider.Surname}|{product.Provider.BirthYear}");
                }
            }
            isSaved = true;
        }

        public void Load(string filePath)
        {
            if (!File.Exists(filePath)) return;
            using (var reader = new System.IO.StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        string name = parts[0];
                        string lastName = parts[1];
                        if (decimal.TryParse(lastName, out decimal price))
                        {
                            Person person = new Person(Name = "Unknown", lastName, DateTime.Now);
                            Product product = new Product(name, person, price);

                        }
                    }
                }
            }
            isSaved = true;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < products.Length; i++)
            {
                yield return products[i];
            }
        }

        public void Sort()
        {
            Array.Sort(products);
            isSaved = false;
        }

        public string ToShortString(string name, ProductCategory category)
        {
            return $"{name}, Category: {category}";
        }

        public override string ToString()
        {
            return $"Name: {Name},\n Opening Date: {OpeningDate},\n Products: {string.Join(", ", Products)},\n Category: {Category},\n Total Cost: {CalculateTotalCost()}";
        }
    }
}
