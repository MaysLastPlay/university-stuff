using System;
using System.Collections.Generic;
using System.Text;
using Module3.enums;

namespace Module3.zoo.animals
{
    internal class Tiger : Animal
    {
        public Tiger(bool canFly, string name, decimal weight) : base(name, weight, AnimalType.Mammal, FoodType.Meat, 360, false)
        {
            this.canFly = canFly;
        }

        public bool canFly { get; }
        public override string SayMyName() => $"Born to crawl, cannot fly.";

        public override string ToString() => base.ToString() + $"\n Can fly: {canFly}";

    }
}
