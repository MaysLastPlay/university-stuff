using System;
using System.Collections.Generic;
using System.Text;
using LabApp9_3.enums;
using LabApp9_3.interfaces;
using LabApp9_3.store.item;

namespace LabApp9_3.store.methods
{
    internal class StoreMethods : IStore
    {
        public void AddItem(Item item)
        {
            if (Store.itemCount < Store.items.Length)
            {
                Store.items[Store.itemCount] = item;
                Store.itemCount++;
            }
            else
            {
                Console.WriteLine("Store is full. Cannot add more items.");
            }
        }

        public void BuyItem(Item item)
        {
            foreach (Item boughtitem in Store.items)
            {
                if (boughtitem.name == item.name)
                {
                    Console.WriteLine($"Item '{item.name}' bought for ${item.price}.");
                    RemoveItem(boughtitem);
                    return;
                }
            }
            Console.WriteLine($"Item '{item.name}' not found in the store.");
        }

        public void RemoveItem(Item item)
        {
            for (int i = 0; i < Store.itemCount; i++)
            {
                if (Store.items[i].name == item.name)
                {
                    for (int j = i; j < Store.itemCount - 1; j++)
                    {
                        Store.items[j] = Store.items[j + 1];
                    }
                    Store.items[Store.itemCount - 1] = default(Item);
                    Store.itemCount--;
                    Console.WriteLine($"Item '{item.name}' removed from the store.");
                    return;
                }
            }
            Console.WriteLine($"Item '{item.name}' not found in the store.");
        }
        public void DisplayByCategory()
        {
            StoreItems category = new StoreItems();
            Console.WriteLine("Store Items:");
            for (int i = 0; i < Store.itemCount; i++)
            {
                if (Store.items[i].category != category)
                {
                    category = Store.items[i].category;
                    Console.WriteLine($"{Store.items[i].name}");
                }
            }
        }
    }
}