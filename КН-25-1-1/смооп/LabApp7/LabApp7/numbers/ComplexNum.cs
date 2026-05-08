using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp7_1.numbers
{
    internal class ComplexNum : DoubleNums
    {
        public ComplexNum(double num1, double num2) : base(num1, num2)
        {
        }

        public override double Sum()
        {
            return this.Num1 + this.Num2;
        }

        public override double Multiply()
        {
            return (this.Num1 * this.Num1) - (this.Num2 * this.Num2);

        }

        public new string ToShortString()
        {
            return $"Real: {this.Num1}, Imaginary: {this.Num2}";
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
