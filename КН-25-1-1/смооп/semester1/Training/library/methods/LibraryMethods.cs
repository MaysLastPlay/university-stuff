using System;
using System.Collections.Generic;
using System.Text;
using Training.interfaces;
using Training.library.item;

namespace Training.library.methods
{
    internal class LibraryMethods : ILibrary
    {
        public void AddItem(Item item)
        {
            if (Library.itemCount < Library.items.Length)
            {
                Library.items[Library.itemCount] = item;
                Library.itemCount++;
            }
        }

        public void RemoveItem(Item item)
        {
            for (int i = 0; i < Library.itemCount; i++)
            {
                if (Library.items[i].Title == item.Title)
                {
                    Library.items[i] = null;
                    Library.itemCount--;
                    Console.WriteLine($"Removed item: {item}");
                    break;
                }
            }
            Console.WriteLine($"Could not find item to remove: {item}");
        }
        public void GetId(int id)
        {
            foreach (Item item in Library.items)
            {
                if (item != null && item.Id == id)
                {
                    Console.WriteLine($"{item.Title} (ID: {item.Id})");
                    return;
                }
            }
            Console.WriteLine($"Could not find item with ID {id}");
        }
        public void DisplayItems()
        {
            foreach (Item i in Library.items)
            {
                if (i != null)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}