using System;
using Module3.zoo.animals;

namespace Module3.zoo.methods
{
    internal class ZooMethods
    {
        public void addAnimals(Aviaries[] aviaries, params Animal[] animals)
        {
            foreach (var animal in animals)
            {
                if (animal == null) continue;

                bool added = false;
                for (int i = 0; i < aviaries.Length; i++)
                {
                    if (aviaries[i] != null && !aviaries[i].IsFull)
                    {
                        aviaries[i].AddToAviary(animal);
                        added = true;
                        break;
                    }
                }

                if (!added) Console.WriteLine($"Could not add {animal.name}: no available aviaries.");
            }
        }

        public void AnimalsInfo(Aviaries[] aviaries)
        {
            Console.WriteLine($"Animals in {Zoo.thename}:");
            foreach (var aviary in aviaries)
            {
                if (aviary != null)
                {
                    for (int i = 0; i < aviary.Length; i++)
                    {
                        if (aviary.curAnimals[i] != null)
                        {
                            Console.WriteLine(aviary.curAnimals[i].ToString());
                        }
                    }
                }
            }
        }

        public void AviariesInfo(Aviaries[] aviaries)
        {
            Console.WriteLine("Aviaries:");
            foreach (var aviary in aviaries)
            {
                if (aviary != null)
                {
                    Console.WriteLine(aviary.ToString());
                }
            }
        }

        public int TotalFoodPerMonth(Aviaries[] aviaries)
        {
            int totalFood = 0;
            foreach (var aviary in aviaries)
            {
                if (aviary != null)
                {
                    for (int i = 0; i < aviary.Length; i++)
                    {
                        if (aviary.curAnimals[i] != null)
                        {
                            totalFood += (int)aviary.curAnimals[i].foodPerMonth;
                        }
                    }
                }
            }
            return totalFood;
        }
    }
}
