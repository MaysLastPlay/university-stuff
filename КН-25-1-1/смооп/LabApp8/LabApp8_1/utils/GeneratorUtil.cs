using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using LabApp8_1.lb6;

namespace LabApp8_1.utils
{

    internal class GeneratorUtil
    {
        private static Random random = new Random();

        private static string firstNames = "Tech,Style,Foodie,Bookworm,Furniture";
        private static string lastNames = "Store,Hub,Corner,World,Mart";
        private static string productNames = "Laptop,Shirt,Pizza,Novel,Sofa";

        public static Product CreateProduct()
        {
            var productNameArray = productNames.Split(',');
            var firstNameArray = firstNames.Split(',');
            var lastNameArray = lastNames.Split(',');

            string prodName = productNameArray[random.Next(productNameArray.Length)];
            string providerName = firstNameArray[random.Next(firstNameArray.Length)];
            string providerSurname = lastNameArray[random.Next(lastNameArray.Length)];

            return new Product
            {
                Name = prodName,
                Price = random.Next(100, 1000),
                Provider = new Person
                {
                    Name = providerName,
                    Surname = providerSurname,
                    BirthYear = random.Next(1950, 2005)
                }
            };
        }
    }
}