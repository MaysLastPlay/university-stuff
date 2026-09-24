using System;
using System.Collections.Generic;
using System.Text;
using LabApp9_3.enums;
using LabApp9_3.store;
using LabApp9_3.store.item;

namespace LabApp9_3.testing
{
    internal class TestClass
    {
        public static void Test()
        {
            Store store = new Store(5);
            Item item1 = new Item("Gems", "3000 Gems.", StoreItems.Money, 99.99m, Currency.RealMoney);
            Item item2 = new Item("Brawl Pass", "A Game Pass with many resources.", StoreItems.GamePass, 19.99m, Currency.RealMoney);
            Item item3 = new Item("Leon", "New Legendary Brawler.", StoreItems.SpecialItem, 49.99m, Currency.Gems);
            Item item4 = new Item("Special Promotion", "Limited time offer. Get new any legendary brawler for 40% off!", StoreItems.SpecialPromotions, 29.99m, Currency.RealMoney);

            store.AddItem(item1);
            store.AddItem(item2);
            store.AddItem(item3);
            store.AddItem(item4);
            store.DisplayByCategory();

            Console.WriteLine($"\nItem Info: {item1.ToString()}\nItem Info: {item2.ToString()}\nItem Info: {item3.ToString()}\nItem Info: {item4.ToString()}");
            store.BuyItem(item2);
            store.DisplayByCategory();
        }
    }
}
