using Module3.testing;
using Module3.zoo;
using Module3.zoo.methods;

ZooMethods ZooMethods = new ZooMethods();
Zoo zoo = new Zoo("My Zoo");
TestClass.Zoo(zoo);
TestClass.Methods(zoo);
ZooMethods.addAnimals(zoo.aviaries);
ZooMethods.AviariesInfo(zoo.aviaries);
ZooMethods.AnimalsInfo(zoo.aviaries);
Console.WriteLine($"Total food per month: {ZooMethods.TotalFoodPerMonth(zoo.aviaries)} kg.");
