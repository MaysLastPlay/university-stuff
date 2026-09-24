using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;
using LabApp9_3.enums;
using LabApp9_3.interfaces;
using LabApp9_3.store.item;
using LabApp9_3.store.methods;

namespace LabApp9_3.store
{
    internal class Store : IStore
    {
        public static Item[] items;
        public static int itemCount;
        public StoreMethods methods = new StoreMethods();

        public Store(int size)
        {
            items = new Item[size];
            itemCount = 0;
        }

        public void AddItem(Item item) => methods.AddItem(item);
        public void RemoveItem(Item item) => methods.RemoveItem(item);

        public void BuyItem(Item item) => methods.BuyItem(item);
        public void DisplayByCategory() => methods.DisplayByCategory();
    }
}
