using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp8_1.lb6
{
    internal class Product : IComparable, ICloneable
    {
        private string name;
        private decimal price;
        private Person provider;

        public Product(string name, Person provider, decimal price)
        {
            this.name = name;
            this.provider = provider;
            Price = price;
        }

        public Product() {
            provider = new Person("Default", "Provider", new DateTime(1990, 1, 1));
            name = "Default Product";
            price = 0;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Person Provider
        {
            get { return provider; }
            set { provider = value; }
        }
        public decimal Price
        {
            get { return price; }
            set
            {
                if (value >= 0) price = value;
                else throw new ArgumentException("Price cannot be negative.");
            }
        }

        public override string ToString()
        {
            return $"{Name}, Price: {Price}, Provider: {Provider}";
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Product otherProduct = obj as Product;
            if (otherProduct != null)
                return this.Price.CompareTo(otherProduct.Price);
            else
                throw new ArgumentException("Object is not a Product");
        }

        public object Clone()
        {
            return new Product(this.Name, (Person)this.Provider.Clone(), this.Price);
        }
    }
}
