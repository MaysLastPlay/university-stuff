using System;
using System.Collections.Generic;
using System.Text;
using LabApp10_2.suitcase;

namespace LabApp10_2.testing
{
    internal class TestClass
    {

        public static void Run()
        {

            Suitcase suitcase = new Suitcase("Blue", "Delsey", 40.0, 4);
            suitcase.AddItem(new Item("Shirt", 0.5f, ItemPriority.Medium));
            suitcase.AddItem(new Item("Pants", 0.7f, ItemPriority.High));
            suitcase.AddItem(new Item("Shoes", 1.0f, ItemPriority.Low));
            suitcase.AddItem(new Item("Toiletries", 0.3f, ItemPriority.Medium));
            Console.WriteLine("Suitcase 1: " + suitcase);
            Console.WriteLine("Removed Item: ");
            suitcase.RemoveItem(new Item("Shoes", 1.0f, ItemPriority.Low));
        }
    }
}
