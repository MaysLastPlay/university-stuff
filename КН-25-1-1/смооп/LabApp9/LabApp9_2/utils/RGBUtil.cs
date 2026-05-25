using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp9_2.utils
{
    internal struct RGBUtil
    {
        private byte[] _rgb;
        public byte red;
        public byte green;
        public byte blue;
        public byte[] ColorInfo(byte red, byte green, byte blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            _rgb = new byte[] { red, green, blue };
            return _rgb;
        }
        public RGBUtil(byte Red, byte Green, byte Blue)
        {
            red = Red;
            green = Green;
            blue = Blue;
        }

        public string GetHex() => $"#{red:X2}{green:X2}{blue:X2}";

        public (double Cyan, double Magenta, double Yellow, double Key) GetCMYK()
        {
            double r = red / 255.0;
            double g = green / 255.0;
            double b = blue / 255.0;

            double max = r;
            if (g > max) max = g;
            if (b > max) max = b;
            if (max == 0)
            return (0, 0, 0, 1);

            double k = 1 - max;
            double c = (max - r) / max;
            double m = (max - g) / max;
            double y = (max - b) / max;
            return (Math.Round(c, 2), Math.Round(m, 2), Math.Round(y, 2), Math.Round(k, 2));
        }

        public (double H, double S, double L) GetHSL()
        {
            double r = red / 255.0;
            double g = green / 255.0;
            double b = blue / 255.0;
            double max = r;
            if (g > max) max = g;
            if (b > max) max = b;
            double min = r;
            if (g < min) min = g;
            if (b < min) min = b;
            double h, s, l = (max + min) / 2.0;
            if (max == min)
            {
                h = s = 0;
            }
            else
            {
                double d = max - min;
                s = l > 0.5 ? d / (2.0 - max - min) : d / (max + min);
                if (max == r)
                    h = (g - b) / d + (g < b ? 6 : 0);
                else if (max == g)
                    h = (b - r) / d + 2;
                else
                    h = (r - g) / d + 4;
                h /= 6;
            }
            return (Math.Round(h * 360), Math.Round(s * 100), Math.Round(l * 100));
        }
    }
}
