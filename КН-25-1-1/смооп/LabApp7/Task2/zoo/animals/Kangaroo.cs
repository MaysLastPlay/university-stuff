using System;
using System.Collections.Generic;
using System.Text;
using LabApp7_2.enums;

namespace LabApp7_2.zoo.animals
{
    internal class Kangaroo : Animal
    {
        public Kangaroo(string name, decimal weight, AnimalType type, FoodType foodType, bool canLiveWithOtherAnimals) : base(name, weight, type, foodType, canLiveWithOtherAnimals)
        {
        }
        public override string Name { get => base.Name; set => base.Name = value; }
        public override decimal Weight { get => base.Weight; set => base.Weight = value; }

        public override double DailyFoodIntake { get => base.DailyFoodIntake; set => base.DailyFoodIntake = value; }
        public override double MonthlyFoodIntake { get => base.MonthlyFoodIntake; set => base.MonthlyFoodIntake = value; }
        public override string ToString() => $"Name: {Name}, Weight: {Weight}, Type: {Type}, Food Type: {FoodType}, Daily Food Intake: {DailyFoodIntake}, Monthly Food Intake: {MonthlyFoodIntake},  Can Live with Other Animals: {CanLiveWithOtherAnimals}";

        public override string ExtraInfo() => $"HashCode: {GetHashCode()}, Equals: {Equals(this)}";
    }
}
