using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1
{
    internal class Stuff
    {
        public static double Value()
        {
            if (double.TryParse(Console.ReadLine(), out double wa)) {
            Console.WriteLine("You're good to go");
        } else {
                Console.WriteLine("You wrote something wrong, try again");
            }
            return wa;
        }
        public static void MyTask1()
        {
            int attempt = 3;
            double x = 0;
            double y = 0;
            double z = 0;
            double w;
            double f;
            double s;

            //do
            //{
                Console.WriteLine("Write x:");
                x = Value();
                Console.WriteLine("Write y:");
                y = Value();
                Console.WriteLine("Write z:");
                z = Value();

                f = Math.Pow(Math.Abs(Math.Cos(x) - Math.Cos(y)), (1 + 2 * Math.Pow(Math.Sin(y), 2)));
                s = (1 + z + Math.Pow(z, 2) / 2 + Math.Pow(z, 3) / 3 + Math.Pow(z, 4) / 4);
                w = f * z;
                Console.WriteLine($"result = {w}");
            //} while (attempt != 4);

        }
    }
}
