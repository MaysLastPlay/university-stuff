using System;
using System.Collections.Generic;
using System.Text;
using LabApp10_2.suitcase.item;

namespace LabApp10_2.events
{
    internal class SuitcaseEventHandler
    {
        public delegate void ItemEventHandler(Item item, string message);
        public event ItemEventHandler? OnEventOccured;

        public void TriggerItemEvent(Item item, string message)
        {
            OnEventOccured?.Invoke(item, message);
            Console.WriteLine(message);
        }
    }
}
