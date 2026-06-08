
using System;
using System.Collections.Generic;
using System.Text;
using Module3.enums;

namespace Module3.zoo.animals
{
    internal class Crocodile : Animal
    {
        public Crocodile(bool canDig, string name, decimal weight) : base(name, weight, AnimalType.Reptile, FoodType.Meat, 160, false)
        {
            this.canDig = canDig;
        }

        public bool canDig { get; }
        public override string SayMyName() => $"Go swim till you're blue!";
        public override string ToString() => base.ToString() + $"\nCan Dig: {canDig}";
    }
}
