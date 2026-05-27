using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp10_2.suitcase
{
    internal class Suitcase
    {
        public string color { get; set; }
        public string developerName { get; set; }
        public double capacity { get; set; }
        public Item?[] items { get; set; }
        public int maxitems { get; set; }

        public Suitcase(string color, string manufacturer, double capacity, int itemCount)
        {
            this.color = color;
            this.developerName = manufacturer;
            this.capacity = capacity;
            this.maxitems = itemCount;
            items = new Item?[itemCount];
        }

        public Suitcase()
        {
            color = "Unknown";
            developerName = "Unknown";
            capacity = 0.0;
            maxitems = 0;
            items = new Item?[maxitems];
        }

        public void AddItem(Item item)
        {
            for (int i = 0; i < maxitems; i++)
            {
                if (items[i] == null)
                {
                    items[i] = item;
                    return;
                }
            }
            Console.WriteLine("Suitcase is full. Cannot add more items.");
        }

        public void RemoveItem(Item item)
        {
            for (int i = 0; i < maxitems; i++)
            {
                if (items[i] == item)
                {
                    items[i] = null;
                    return;
                }
            }
            Console.WriteLine($"Removed Item: {item.Name}.");
        }

        public string ItemsList(Item?[] items)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in items)
            {
                if (item != null)
                {
                    sb.AppendLine(item.ToString());
                }
            }
            return sb.ToString();
        }

        public override string ToString() => $"Suitcase: Color: {color}, Developer: {developerName}, Capacity: {capacity} kg, Items:\n{ItemsList(items)}";
    }
}
