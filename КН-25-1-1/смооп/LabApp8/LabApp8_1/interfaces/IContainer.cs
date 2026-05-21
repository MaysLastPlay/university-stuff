using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LabApp8_1.interfaces
{
    internal interface IContainer<TElement>
    {
        int Count { get; }
        object this[int index] { get; set; }
        void Add(TElement element);
        void Delete(TElement element);
    }
}
