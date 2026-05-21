using System;
using System.Collections.Generic;
using System.Text;
using LabApp8_1.lb6;
using LabApp8_1.utils;

namespace LabApp8_1.utils
{
    internal class TestUtil
    {
        public static void Test()
        {
            Shop shop = new Shop();
            shop.Name = "Tech Store";
            Console.WriteLine($"Shop Name: {shop.Name}\nAdd");
            for (int i = 0; i < 6; i++)
            {
                Product product = GeneratorUtil.CreateProduct();
                shop.Add(product);
                Console.WriteLine(product.Name, product.Price, product.Provider);
            }
            Console.WriteLine("\nSort Items:");
            shop.Sort();
            foreach (Product product in shop.Products)
            {
                Console.WriteLine(product.Name, product.Price, product.Provider);
            }
            Console.WriteLine("\nCopying Shop:");
            Shop shop1 = new Shop();
            shop1.Name = "Copy of Tech Store";
            for (int i = 0; i < (shop.Count < 2 ? shop.Count : 2); i++)
            {
                shop1.Add(shop.Products[i]);
            }
            Console.WriteLine($"Shop Name: {shop1.Name}\nNumber of Items: {shop1.Count}");
            shop1.Save("shop_data.txt");
            Console.WriteLine("\nSaved shop to 'shop_data.txt'.");
        }
    }
}
