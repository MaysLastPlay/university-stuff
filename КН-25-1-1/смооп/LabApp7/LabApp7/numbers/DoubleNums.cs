using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp7_1.numbers
{
    internal class DoubleNums
    {
        protected double Num1 { get; set; }
        protected double Num2 { get; set; }

        public DoubleNums(double num1, double num2)
        {
            this.Num1 = num1;
            this.Num2 = num2;
        }

        public virtual double Sum()
        {
            return this.Num1 + this.Num2;
        }
        public virtual double Multiply()
        {
            return this.Num1 * this.Num2;
        }

        public string ToShortString() => $"Num1: {this.Num1}, Num2: {this.Num2}";
        public override string ToString() => $"Num1: {this.Num1}, Num2: {this.Num2}, Sum: {this.Sum()}, Multiplied: {this.Multiply()}";
        public string ExtraInfo() => $" HashCode: {this.GetHashCode()}, Equals: {this.Equals(this)}";

        public override int GetHashCode()
        {
                int h1 = this.Num1.GetHashCode();
                int h2 = this.Num2.GetHashCode();
                return (h1 * 397) ^ h2;
        }

        public override bool Equals(object? obj)
        {
            if (obj is DoubleNums other)
            {
                return this.Num1 == other.Num1 && this.Num2 == other.Num2;
            }
            return false;
        }
    }
}