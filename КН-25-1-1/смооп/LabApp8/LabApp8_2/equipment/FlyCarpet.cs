using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp8_2.equipment
{
    internal class FlyCarpet : Device
    {
        public FlyCarpet(string name, string model, decimal price, int horsePower, string material) : base(name, model, 10m, 0, material) { }
        public override bool isElectric => false;
        public override bool isStarted => false;

        public override string Material => "Wool";

        public override string ToString()
        {
            return base.ToString() + $", Horsepower: {HorsePower}, Material: {Material}";
        }
    }
}
