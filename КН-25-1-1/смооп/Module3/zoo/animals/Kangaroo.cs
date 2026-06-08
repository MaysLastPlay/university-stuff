using System;
using System.Collections.Generic;
using System.Text;
using Module3.enums;

namespace Module3.zoo.animals
{
    internal class Kangaroo : Animal
    {
        public Kangaroo(bool canRun, string name, decimal weight) : base(name, weight, AnimalType.Mammal, FoodType.Plants, 80, true)
        {
            this.canRun = canRun;
        }

        public bool canRun { get; }
        public override string SayMyName() => $"Just no, go jump all the way!";

        public override string ToString() => base.ToString() + $"\nCan Run: {canRun}";
    }
}
