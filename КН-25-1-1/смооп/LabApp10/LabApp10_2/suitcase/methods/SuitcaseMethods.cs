using System;
using System.Collections.Generic;
using System.Text;
using LabApp10_2.events;
using LabApp10_2.suitcase.item;

namespace LabApp10_2.suitcase.methods
{
    internal class SuitcaseMethods
    {
        public Item?[] items { get; set; }
        public const int maxItems = 4;
        SuitcaseEventHandler suitcaseEventHandler = new SuitcaseEventHandler();

        public SuitcaseMethods()
        {
            items = new Item?[maxItems];
        }
        public void AddItem(Item item, Item[] items)
        {
            for (int i = 0; i < maxItems; i++)
            {
                if (items[i] == null)
                {
                    items[i] = item;
                    suitcaseEventHandler.TriggerItemEvent(item, $"Added item: {item.Name} to the suitcase.");
                    return;
                }
            }
            if (items.Length >= maxItems)
                suitcaseEventHandler.TriggerItemEvent(item, $"Failed to add item: {item.Name}. Suitcase is full.");
        }

        public void RemoveItem(Item item)
        {
            for (int i = 0; i < maxItems; i++)
            {
                if (items[i] == item)
                {
                    items[i] = null;
                    return;
                }
            }
            if (items != null)
                suitcaseEventHandler.TriggerItemEvent(item, $"Removed item: {item.Name} from the suitcase.");
            else
                suitcaseEventHandler.TriggerItemEvent(item, $"Failed to remove item. Suitcase is empty.");
        }

        public void RemoveAllItems(Item[] items)
        {
            for (int i = 0; i < maxItems; i++)
            {
                items[i] = null;
            }
            suitcaseEventHandler.TriggerItemEvent(null, "All items removed from the suitcase.");
        }

        public static string ItemsList(Item?[] items)
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
    }
}
