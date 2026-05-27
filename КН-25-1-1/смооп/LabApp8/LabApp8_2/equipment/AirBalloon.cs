using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp8_2.equipment
{
    internal class AirBalloon : Device
    {
        public AirBalloon(string name, string model, decimal price, int horsePower, string material) : base(name, model, 5000m, 100, material) { }
        public override bool isElectric => false;
        public override bool isStarted => false;
        public override string Material => "Rubber";
        public override string ToString()
        {
            return base.ToString() + $", Horsepower: {HorsePower}, Material: {Material}";
        }
    }
}
