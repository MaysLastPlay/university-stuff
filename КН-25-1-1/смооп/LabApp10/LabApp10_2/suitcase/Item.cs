using System;
using System.Collections.Generic;
using System.Text;
using LabApp10_2.suitcase;

namespace LabApp10_2.suitcase
{
    public class Item
    {
        public string Name { get; set; }
        public float Weight { get; set; }
        public ItemPriority Priority { get; set; }

        public Item(string name, float weight, ItemPriority priority) {
            this.Name = name;
            this.Weight = weight;
            this.Priority = priority;
        }

        public Item()
        {
            Name = "Unknown";
            Weight = 0.0f;
            Priority = ItemPriority.Low;
        }

        public override string ToString() => $"Item: {Name}, Weight: {Weight} kg, Priority: {Priority}";
    }
}
