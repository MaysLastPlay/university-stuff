using System;
using System.Collections.Generic;
using System.Text;
using Module3.zoo.animals;
using Module3.zoo.methods;

namespace Module3.zoo
{
    internal class Zoo
    {
        public static string thename { get; private set; }
        public const int MaxAviaryNum = 1;
        public Aviaries[] aviaries = new Aviaries[MaxAviaryNum];
        public ZooMethods Methods { get; } = new ZooMethods();
        public Zoo(string name)
        {
            thename = name;

            for (int i = 0; i < aviaries.Length; i++)
            {
                aviaries[i] = new Aviaries();
            }
        }

        public void addAnimals(params Animal[] animals)
        {
            Methods.addAnimals(aviaries, animals);
        }

        public void AnimalsInfo() => Methods.AnimalsInfo(aviaries);
        public void AviariesInfo() => Methods.AviariesInfo(aviaries);
        public int TotalFoodPerMonth() => Methods.TotalFoodPerMonth(aviaries);
    }
}
