using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LabApp7_2.zoo
{
    internal class Aviaries
    {
        public const int MaxAnimals = 3;
        public int countedAnimals = 0;
        public Animal[] curAnimals = new Animal[MaxAnimals];
        public bool IsFull => countedAnimals >= MaxAnimals;

        public int Length { get { return countedAnimals; } }

        public Aviaries(Animal[] animal)
        {
            this.curAnimals = animal;
        }

        public Aviaries()
        {
        }

        public void AddToAviary(params Animal[] animals)
        {
            if (countedAnimals + animals.Length > MaxAnimals) throw new Exception("Aviary is full");

           int curLength = countedAnimals;
           Array.Resize(ref curAnimals, curLength + animals.Length);
           Array.Copy(animals, 0, curAnimals, curLength, animals.Length);

            countedAnimals += animals.Length;
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
