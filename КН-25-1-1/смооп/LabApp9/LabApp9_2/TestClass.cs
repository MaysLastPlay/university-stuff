using System;
using System.Collections.Generic;
using System.Text;
using LabApp9_2.utils;

namespace LabApp9_2
{
    internal class TestClass
    {
        public static void TestRGB()
        {
         RGBUtil rgb = new RGBUtil();
            byte red = 255;
            byte green = 30;
            byte blue = 90;
            rgb.ColorInfo(red, green, blue);
            Console.WriteLine($"RGB: {red}.{green}.{blue}\nHex: {rgb.GetHex()}\n CMYK: {rgb.GetCMYK()}\n HSL: {rgb.GetHSL()}");
        }
    }
}
