using System;
using System.Collections.Generic;
using System.Text;
using LabApp9_3.store;

namespace LabApp9_3.interfaces
{
    internal interface IStore
    {
        void AddItem(Item item);
        void RemoveItem(Item item);
        void DisplayItems();
    }
}
