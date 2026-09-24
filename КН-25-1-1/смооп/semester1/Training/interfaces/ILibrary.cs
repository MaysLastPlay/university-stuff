using System;
using System.Collections.Generic;
using System.Text;
using Training.library.item;

namespace Training.interfaces
{
    internal interface ILibrary
    {
        void AddItem(Item item);
        void RemoveItem(Item item);
        void DisplayItems();
        void GetId(int id);
    }
}
