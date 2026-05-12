using System;
using System.Collections.Generic;
using System.Text;
using LabApp7_2.enums;
using LabApp7_2.zoo.animals;

namespace LabApp7_2.zoo
{
    internal class Zoo
    {
        public void GetAnimalsInfo()
        {
            Animal[] animals =
                [
                    new Tiger("Sheru", 200m, AnimalType.Carnivore, FoodType.Meat, false),
                    new Kangaroo("Kanga", 85m, AnimalType.Herbivore, FoodType.Plants, true),
                    new Crocodile("Croc", 500m, AnimalType.Carnivore, FoodType.Meat, false),
                ];

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
                Console.WriteLine(animal.ExtraInfo());
            }
        }
    }
}