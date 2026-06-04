using System;
using System;
using System.Collections.Generic;
using System.Text;
using LabApp10_2.events;
using LabApp10_2.suitcase;
using LabApp10_2.suitcase.item;
using LabApp10_2.suitcase.methods;

namespace LabApp10_2.testing
{
    internal class TestClass
    {
        public static void Run()
        {
            SuitcaseMethods method = new SuitcaseMethods();
            Suitcase suitcase = new Suitcase("Blue", "Delsey", 40.0);
            SuitcaseEventHandler sharedHandler = suitcase.suitcaseEventHandler;

            ItemCollector collector = new ItemCollector();
            collector.Init(suitcase, sharedHandler);

            Item shirt = new Item(ItemList.Shirt, 0.5f, ItemPriority.Medium);
            Item pants = new Item(ItemList.Pants, 0.7f, ItemPriority.High);
            Item shoes = new Item(ItemList.Shoes, 1.0f, ItemPriority.Low);
            Item toiletries = new Item(ItemList.Toiletries, 0.3f, ItemPriority.Medium);
            Item extra = new Item(ItemList.FullSuitcaseTest, 0.5f, ItemPriority.Medium);

            shirt.RequestItem(sharedHandler);
            pants.RequestItem(sharedHandler);
            shoes.RequestItem(sharedHandler);
            toiletries.RequestItem(sharedHandler);
            extra.RequestItem(sharedHandler);
            collector.OnRequest(shirt, "wants to be added");
            collector.OnRequest(pants, "wants to be added");
            collector.OnRequest(shoes, "wants to be added");
            collector.OnRequest(toiletries, "wants to be added");
            collector.OnRequest(extra, "wants to be added");

            Console.WriteLine("Suitcase 1: " + suitcase);

            // Removed 1 Item
            var removeditem = suitcase.items[0];
            if (removeditem != null)
            {
                method.RemoveItem(removeditem);
            }

            Console.WriteLine("Suitcase after removal: \n" + suitcase);

            // All Items Removed
            method.RemoveAllItems(suitcase.items);
            Console.WriteLine("Suitcase after removing all items: \n" + suitcase);
        }
    }
}
