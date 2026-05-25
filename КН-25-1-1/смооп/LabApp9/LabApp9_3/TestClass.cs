using System;
using System.Collections.Generic;
using System.Text;
using LabApp9_3.store;

namespace LabApp9_3
{
    internal class TestClass
    {
        public static void Test()
        {
            Store store = new Store(5);
            Item item1 = new Item("Gems", "3000 Gems.", StoreItems.Money, 99.99m);
            Item item2 = new Item("Brawl Pass", "A Game Pass with many resources.", StoreItems.GamePass, 19.99m);
            Item item3 = new Item("Leon", "New Legendary Brawler.", StoreItems.SpecialItem, 49.99m);
            store.AddItem(item1);
            store.AddItem(item2);
            store.AddItem(item3);
            store.DisplayItems();
            Console.WriteLine($"\nItem Info: {item1.ToString()}");
            Console.WriteLine($"\n Item Info: {item2.ToString()}");
            Console.WriteLine($"\nItem Info: {item3.ToString()}");
            store.RemoveItem(item2);
            store.DisplayItems();
        }
    }
}
