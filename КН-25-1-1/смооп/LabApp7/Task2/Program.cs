using LabApp7_2;
using LabApp7_2.enums;
using LabApp7_2.zoo.animals;
using LabApp7_2.zoo;

Zoo zoo = new Zoo("My Zoo");
TestClass.Wa(zoo);
TestClass.Methods(zoo);
zoo.addAnimals();
zoo.AviariesInfo();
zoo.AnimalsInfo();
Console.WriteLine($"Total food per month: {zoo.TotalFoodPerMonth()} kg.");