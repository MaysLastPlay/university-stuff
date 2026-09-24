using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using LabApp10_2.events;
using LabApp10_2.suitcase.item;

namespace LabApp10_2.suitcase.methods
{
    internal class ItemCollector
    {
        private Suitcase? suitcase;
        private Item?[] collectedItems = new Item?[SuitcaseMethods.maxItems];
        private int itemCount = 0;

        public void Init(Suitcase suitcase, SuitcaseEventHandler handler)
        {
            this.suitcase = suitcase;
            handler.OnEventOccured += OnRequest;
        }

        public void OnRequest(Item item, string message)
        {
            if (message.Contains("wants to be added"))
            {

                if (itemCount < collectedItems.Length)
                {
                    collectedItems[itemCount] = item;
                    itemCount++;
                }

                if (suitcase != null)
                {
                    suitcase.AddItem(item);
                }
            }
        }
    }
}