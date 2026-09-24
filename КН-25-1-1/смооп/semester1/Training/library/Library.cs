using System;
using System.Collections.Generic;
using System.Text;
using Training.library.item;
using Training.enums;
using Training.interfaces;
using Training.library.methods;

namespace Training.library
{
    internal class Library : ILibrary
    {
        public LibraryMethods methods = new LibraryMethods();
        public string LibraryName { get; private set; }
        public static Item[] items;
        public static int itemCount = 0; 

        public Library(string libraryName, int size)
        {
            LibraryName = libraryName;
            items = new Item[size];
        }

        public void AddItem(Item item) => methods.AddItem(item);
        public void RemoveItem(Item item) => methods.RemoveItem(item);
        public void GetId(int id) => methods.GetId(id);
        public void DisplayItems() => methods.DisplayItems();
    }
} 