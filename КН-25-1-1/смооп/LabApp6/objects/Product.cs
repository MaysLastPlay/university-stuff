using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp6.objects
{
    internal class Product
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
            set { if (value >= 0) price = value;
            else throw new ArgumentException("Price cannot be negative.");
            }
        }

        public override string ToString()
        {
            return $"{Name}, Price: {Price}, Provider: {Provider}";
        }
    }
}
