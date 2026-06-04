using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using LabApp10_2.events;
using LabApp10_2.suitcase.item;
using LabApp10_2.suitcase.methods;

namespace LabApp10_2.suitcase
{
    internal class Suitcase
    {
        public SuitcaseEventHandler suitcaseEventHandler = new SuitcaseEventHandler();
        public string color { get; set; }
        public string developerName { get; set; }
        public double capacity { get; set; }
        public Item?[] items { get; set; }

        public Suitcase(string color, string manufacturer, double capacity)
        {
            this.color = color;
            this.developerName = manufacturer;
            this.capacity = capacity;
            this.items = new Item?[SuitcaseMethods.maxItems];
        }

        public Suitcase()
        {
            color = "Unknown";
            developerName = "Unknown";
            capacity = 0.0;
            items = new Item?[SuitcaseMethods.maxItems];
        }

        public void AddItem(Item item)
        {
            new SuitcaseMethods().AddItem(item, items);
        }

        public string ItemsList => SuitcaseMethods.ItemsList(items);

        public override string ToString() => $"Suitcase: Color: {color}, Developer: {developerName}, Capacity: {capacity} kg, \nItems:\n{SuitcaseMethods.ItemsList(items)}";
    }
}
