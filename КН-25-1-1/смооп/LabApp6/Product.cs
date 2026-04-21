using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp6
{
    internal class Product
    {
        private string name;
        private decimal price;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}";
        }
    }
}
