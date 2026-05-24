using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LabApp8_2.equipment
{
    internal class Airplane : Device
    {
        public Airplane(string name, string model, decimal price, int horsePower, string material) : base(name, model, 100000m, 10000, material)
        {
        }
        public override bool isElectric => true;
        public override bool isStarted => false;

        public override string Material => "Aluminum";

        public override string ToString()
        {
            return base.ToString() + $", Horsepower: {HorsePower}, Material: {Material}";
        }
    }
}
