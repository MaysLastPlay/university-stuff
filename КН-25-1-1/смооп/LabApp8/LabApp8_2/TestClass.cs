using System;
using System.Collections.Generic;
using System.Text;
using LabApp8_2.equipment;

namespace LabApp8_2
{
    internal class TestClass
    {
      public static void ShowDevices()
        {
            Register register = new Register();
            register.AddDevice(new Airplane("Boeing 747", "747", 100000m, 10000, "Aluminum"));
            register.AddDevice(new FlyCarpet("Carpet", "FlyCarpet", 10m, 0, "Wool"));
            Console.WriteLine(register);
        }
        public static void CloneTest()
        {
            Airplane original = new Airplane("Boeing 747", "747", 100000m, 10000, "Aluminum");
            Device clone = (Device)original.Clone();
            Console.WriteLine("Original: " + original);
            Console.WriteLine("Clone: " + clone);
        }
    }
}
