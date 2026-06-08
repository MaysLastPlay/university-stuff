using System;
using System.Collections.Generic;
using System.Text;
using Module3.interfaces;
using Module3.zoo.animals;
using Module3.zoo.methods;

namespace Module3.zoo
{
    internal class Aviaries
    {
        public const int MaxAnimals = 3;
        public int countedAnimals { get; private set; } = 0;
        public Animal[] curAnimals = new Animal[MaxAnimals];
        public bool IsFull => countedAnimals >= MaxAnimals;
        public int Length => countedAnimals;

        public Aviaries(Animal[] animal)
        {
            this.curAnimals = animal;

            if (animal != null)
            {
                int count = 0;
                foreach (var a in animal) if (a != null) count++;
                this.countedAnimals = count;
            }
        }

        public Aviaries()
        {
        }

        public void AddToAviary(params Animal[] animals)
        {
            foreach (var animal in animals)
            {
                if (animal == null) continue;

                if (IsFull)
                {
                    Console.WriteLine($"Aviary is full! Cannot add {animal.name}");
                    return;
                }

                curAnimals[countedAnimals] = animal;
                countedAnimals++;
            }
        }


        public override string ToString()
        {
            string animalNumInfo = "";
            foreach (var animal in curAnimals)
            {
                animalNumInfo += animal?.name + ", ";
            }
            return $"[{animalNumInfo.TrimEnd(',', ' ')}]";
        }
    }
}
