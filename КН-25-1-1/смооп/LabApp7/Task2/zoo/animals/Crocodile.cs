using System;
using System.Collections.Generic;
using System.Text;
using LabApp7_2.enums;

namespace LabApp7_2.zoo.animals
{
    internal class Crocodile : Animal
    {
        public Crocodile(bool canDig, string name, decimal weight) : base(name, weight, AnimalType.Reptile, FoodType.Meat, 160, true)
        {
            this.canDig = canDig;
        }

        public bool canDig { get; }
        public override string SayMyName() => $"Go swim till you're blue!";
        public override string ToString() => base.ToString() + $"\nCan Dig: {canDig}";
    }
}
