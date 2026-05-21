using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp8_1.interfaces
{
    internal interface IFileContainer<TElement> : IContainer<TElement>
    {
        void Save(string filePath);
        void Load(string filePath);
        bool Saved { get; }
    }
}
