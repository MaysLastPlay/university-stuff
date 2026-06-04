using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using LabApp10_1.things;

namespace LabApp10_1.testing.actions
{
    internal class GeometryAction
    {
        public static void DoGeometryTest()
        {
            Console.WriteLine("Geometry Stuff:");
            double x = 5.9, y = 10.2;
            Console.WriteLine($"Triangle area with sides {x} and {y}: {GeometryThing.TriangleArea(x, y)}");
            Console.WriteLine($"Rectangle area with sides {x} and {y}: {GeometryThing.RectangleArea(x, y)}");
            Console.ReadKey();
        }
    }
}
