using System;
using System.Collections.Generic;
using System.Text;
using LabApp9_3.store.item;
using LabApp9_3.enums;

namespace LabApp9_3.interfaces
{
    internal interface IStore
    {
        void AddItem(Item item);
        void RemoveItem(Item item);
        void BuyItem(Item item);
        void DisplayByCategory();
    }
}
