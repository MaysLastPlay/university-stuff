using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp8_2.equipment
{
    internal class Helicopter : Device
    {
        public Helicopter(string name, string model, decimal price, int horsePower, string material) : base(name, model, 50000m, 5000, material) { }
        public override bool isElectric => false;
        public override bool isStarted => false;

        public override string Material => "Aluminum";

        public override string ToString()
        {
            return base.ToString() + $", Horsepower: {HorsePower}, Material: {Material}";
        }
    }
}
