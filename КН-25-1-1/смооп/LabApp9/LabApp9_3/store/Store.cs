using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;
using LabApp9_3.interfaces;

namespace LabApp9_3.store
{
    internal class Store : IStore
    {
        public Item[] items;
        public int itemCount;

        public Store(int size)
        {
            items = new Item[size];
            itemCount = 0;
        }

        public void AddItem(Item item)
        {
            if (itemCount < items.Length)
            {
                items[itemCount] = item;
                itemCount++;
            }
            else
            {
                Console.WriteLine("Store is full. Cannot add more items.");
            }
        }

        public void DisplayItems()
        {
            Console.WriteLine("Items in the store:");
            for (int i = 0; i < itemCount; i++)
            {
                Console.WriteLine($"- {items[i].name}");
            }
        }

        public void RemoveItem(Item item)
        {
            for (int i = 0; i < itemCount; i++)
            {
                if (items[i].name == item.name)
                {
                    for (int j = i; j < itemCount - 1; j++)
                    {
                        items[j] = items[j + 1];
                    }
                    items[itemCount - 1] = default(Item);
                    itemCount--;
                    Console.WriteLine($"Item '{item.name}' removed from the store.");
                    return;
                }
            }
            Console.WriteLine($"Item '{item.name}' not found in the store.");
        }
    }
}
