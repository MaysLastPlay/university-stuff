using System;
using System.Collections.Generic;
using System.Text;
using LabApp7_2.enums;

namespace LabApp7_2.zoo.animals
{
    internal class Kangaroo : Animal
    {
        private decimal weight;
        private FoodType foodType;
        private double dailyFoodIntake;
        private double monthlyFoodIntake;
        public Kangaroo(string name, decimal weight, AnimalType type, FoodType foodType, bool canLiveWithOtherAnimals) : base(name, weight, type, foodType, canLiveWithOtherAnimals)
        {
            this.weight = weight;
            this.foodType = foodType;
            this.dailyFoodIntake = CalculateDailyFoodIntake((double)weight, GetFoodTypeMultiplier(foodType));
            this.monthlyFoodIntake = CalculateMonthlyFoodIntake();
        }
        public override string Name { get => base.Name; set => base.Name = value; }
        public override decimal Weight { get => base.Weight; set => base.Weight = value; }

        public override string ToString() => $"Name: {Name}, Weight: {Weight}, Type: {Type}, Food Type: {FoodType}, Daily Food Intake: {dailyFoodIntake}, Monthly Food Intake: {monthlyFoodIntake},  Can Live with Other Animals: {CanLiveWithOtherAnimals}";

        public override string ExtraInfo() => $"HashCode: {GetHashCode()}, Equals: {Equals(this)}";
    }
}
