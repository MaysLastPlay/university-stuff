using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp10_1.things
{
    internal static class GeometryThing
    {
        public static Func<double, double, double> TriangleArea => (double a, double b) => (Math.Sqrt(3) / 4) * a * b;
        public static Func<double, double, double> RectangleArea => (double a, double b) => a * b;
    }
}
