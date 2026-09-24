using System;
using System.Collections.Generic;
using System.Text;
using LabApp9_3.enums;

namespace LabApp9_3.store.item
{
    internal struct Item
    {
        public string name { get; set; }
        public string description { get; set; }
        public StoreItems category { get; set; }
        public decimal price { get; set; }
        public Currency currency { get; set; }

        public Item(string name, string description, StoreItems category, decimal price, Currency currency)
        {
            this.name = name;
            this.description = description;
            this.category = category;
            this.price = price;
            this.currency = currency;
        }

        public override string ToString() => $"\nName: {name}\nDescription: {description}\nCategory: {category}\nPrice: {price}";
    }
}
