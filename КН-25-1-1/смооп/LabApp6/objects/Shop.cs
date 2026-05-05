using System;
using System.Collections.Generic;
using System.Text;
using LabApp6.enums;

namespace LabApp6.objects
{
    internal class Shop
    {
        private string name;
        private DateTime openingDate;
        private Product[] products;
        private ProductCategory category;

        public Shop(string name, DateTime openingDate, Product[] products, ProductCategory category)
        {
            this.name = name;
            this.openingDate = openingDate;
            this.products = products;
            this.category = category;
            CalculateTotalCost();
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

        public string ToShortString() { return $"{Name}, Opening Date: {OpeningDate}, Category: {Category}"; }
        public override string ToString()
        {
            return $"Name: {Name},\n Opening Date: {OpeningDate},\n Products: {string.Join(", ", Products)},\n Category: {Category},\n Total Cost: {CalculateTotalCost()}";
        }

    }
}
