using System;
using System.Collections.Generic;
using System.Text;
using LabApp8_2.interfaces;

namespace LabApp8_2
{
    internal abstract class Device : IDevice, IEngine, IPart, ICloneable, IComparable<Device>
    {
        public string Name { get; protected set; }
        public string Model { get; protected set; }
        public abstract bool isElectric { get; }
        public decimal Price { get; protected set; }
        public abstract bool isStarted { get;}
        public int HorsePower { get; protected set; }
        public abstract string Material { get; }

        public Device(string name, string model, decimal price, int horsePower, string material)
        {
            this.Name = name;
            this.Model = model;
            this.Price = price;
            this.HorsePower = horsePower;
        }

        public Device() {
            Name = "Unknown";
            Model = "Unknown";
            Price = 0;
            HorsePower = 0;
        }

        public override string ToString()
        {
            return $"Device: {Name}, Model: {Model}, Electric: {isElectric}, Price: {Price}";
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(Device other)
        {
            if (other == null) return 1;
            int priceComparison = Price.CompareTo(other.Price);
            if (priceComparison != 0) return priceComparison;
            return Name.CompareTo(other.Name);
        }
    }
}
