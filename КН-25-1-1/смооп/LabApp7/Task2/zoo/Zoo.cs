using System;
using System.Collections.Generic;
using System.Text;
using LabApp7_2.enums;
using LabApp7_2.zoo.animals;

namespace LabApp7_2.zoo
{
    internal class Zoo
    {
        private string thename { get; set; }
        public const int MaxAviaryNum = 1;
        private Aviaries[] aviaries = new Aviaries[MaxAviaryNum];
        public Zoo(string name) {
            this.thename = name;
        }

        public void addAnimals(params Animal[] animals)
        {
            foreach (var aviary in aviaries)
            {
                for (int i = 0; i < aviaries.Length; i++)
                {
                    if (aviaries[i] == null || aviaries[i].Length == 0)
                    {
                        aviaries[i] = new Aviaries();
                        aviaries[i].AddToAviary(animals);
                        aviaries[i].IsFull.ToString();
                    }
                }
            }
        }
        public void AviariesInfo()
        {
            Console.WriteLine("Aviaries:");
            foreach (var aviary in aviaries)
            {
                Console.WriteLine($"{aviary?.ToString()}");
            }
        }
        public void AnimalsInfo()
        {
            Console.WriteLine($"Animals in {thename}:");
            foreach (var aviary in aviaries)
            {
                 if (aviary != null)
                    foreach (var animal in aviary.curAnimals)
                    {
                            Console.WriteLine($"{animal?.ToString()}");
                    }
            }
        }

        public int TotalFoodPerMonth()
        {
            int totalFood = 0;
            foreach (var aviary in aviaries)
            {
                    if (aviary != null)
                    foreach (var animal in aviary.curAnimals)
                    {
                            if (animal != null)
                            totalFood += (int)animal.foodPerMonth;
                    }
            }
            return totalFood;
        }
    }
}