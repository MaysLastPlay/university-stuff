using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp9_3.store
{
    internal struct Item
    {
        public string name { get; set; }
        public string description { get; set; }
        public StoreItems category { get; set; }
        public decimal price { get; set; }

        public Item(string name, string description, StoreItems category, decimal price)
        {
            this.name = name;
            this.description = description;
            this.category = category;
            this.price = price;
        }

        public override string ToString() => $"Name: {name}\nDescription: {description}\nCategory: {category}\nPrice: ${price}";
    }
}
