using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp8_2.interfaces
{
    internal interface IDevice
    {
        string Name { get; }
        string Model { get; }
        bool isElectric { get; }
        decimal Price { get; }
    }
}
