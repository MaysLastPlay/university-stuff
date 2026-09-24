using System;
using System.Collections.Generic;
using System.Text;
using LabApp10_2.events;

namespace LabApp10_2.suitcase.item
{
    internal class Item
    {
        public ItemList Name { get; set; }
        public float Weight { get; set; }
        public ItemPriority Priority { get; set; }

        public Item(ItemList name, float weight, ItemPriority priority) {
            this.Name = name;
            this.Weight = weight;
            this.Priority = priority;
        }

        public Item()
        {
            Weight = 0.0f;
            Priority = ItemPriority.Low;
        }

        public void RequestItem(SuitcaseEventHandler handler)
        {
            string message = $"Item {Name} wants to be added to the suitcase.";
            handler.TriggerItemEvent(this, message);
        }

        public override string ToString() => $"Item: {Name}, Weight: {Weight} kg, Priority: {Priority}";
    }
}
