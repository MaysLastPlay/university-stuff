using System;
using System.Collections.Generic;
using System.Text;
using LabApp7_2.zoo;
using LabApp7_2.zoo.animals;

namespace LabApp7_2
{
    internal class TestClass
    {
        public static void Wa(Zoo zoo)
        {
            Tiger tiger = new Tiger(false, "Tigris", 200);
            Kangaroo kangaroo = new Kangaroo(false, "Kanga", 150);
            Crocodile crocodile = new Crocodile(false, "Croco", 300);
            Tiger tiger1 = new Tiger(true, "Panthera", 250);
            zoo.addAnimals(tiger, kangaroo, crocodile);
            zoo.addAnimals(tiger1);
        }

        public static void Methods(Zoo zoo)
        {
            Console.WriteLine("Test Methods:");
            Tiger tiger = new Tiger(false, "Tigris", 200);
            Tiger tiger1 = new Tiger(true, "Panthera", 250);
            Console.WriteLine($"Equals: {tiger.Equals(tiger1)}\nHashcode 1: {tiger.GetHashCode()}\nHashcode 2: {tiger1.GetHashCode()}");
        }
    }
}
