using System;
using Module3.zoo;
using Module3.zoo.animals;

namespace Module3.testing
{
    internal class TestClass
    {
        public static void Zoo(Zoo zoo)
        {
            Tiger tiger = new Tiger(false, "Tigris", 200);
            Kangaroo kangaroo = new Kangaroo(false, "Kanga", 150);
            Crocodile crocodile = new Crocodile(false, "Croco", 300);
            zoo.addAnimals(tiger, kangaroo, crocodile);
        }

        public static void Methods(Zoo zoo)
        {
            Console.WriteLine("Test Methods:");
            Tiger tiger = new Tiger(false, "Tigris", 200);
            Tiger tiger1 = new Tiger(true, "Panthera", 250);

            Console.WriteLine($"Equals: {tiger.Equals(tiger1)}");
            Console.WriteLine($"Hashcode 1: {tiger.GetHashCode()}");
            Console.WriteLine($"Hashcode 2: {tiger1.GetHashCode()}");
        }
    }
}