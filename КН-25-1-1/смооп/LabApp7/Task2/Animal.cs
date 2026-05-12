using System;
using System.Collections.Generic;
using System.Text;
using LabApp7_2.enums;

namespace LabApp7_2
{
    internal class Animal
    {
        private string name;
        private decimal weight;
        private AnimalType type;
        private FoodType foodType;
        private double dailyFoodIntake;
        private double monthlyFoodIntake;
        private bool canLiveWithOtherAnimals;

        public Animal(string name, decimal weight, AnimalType type, FoodType foodType, bool canLiveWithOtherAnimals)
        {
            this.name = name;
            this.weight = weight;
            this.type = type;
            this.foodType = foodType;
            this.monthlyFoodIntake = CalculateMonthlyFoodIntake();
            this.dailyFoodIntake = CalculateDailyFoodIntake((double)weight, GetFoodTypeMultiplier(foodType));
            this.canLiveWithOtherAnimals = canLiveWithOtherAnimals;
        }

        public double GetFoodTypeMultiplier(FoodType foodType)
        {
            switch (foodType)
            {
                case FoodType.Meat:
                    return 0.02;
                case FoodType.Plants:
                    return 0.01;
                case FoodType.Insects:
                    return 0.005;
                case FoodType.Vegetables:
                    return 0.015;
                case FoodType.Fruits:
                    return 0.025;
                default:
                    throw new ArgumentException("Invalid food type");
            }
        }

        public double CalculateDailyFoodIntake(double weight, double foodTypeMultiplier)
        {
            return weight * foodTypeMultiplier;
        }

        public double CalculateMonthlyFoodIntake()
        { 
            return dailyFoodIntake * 31;
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public AnimalType Type
        {
            get { return type; }
            set { type = value; }
        }

        public FoodType FoodType
        {
            get { return foodType; }
            set { foodType = value; }
        }

        public virtual decimal Weight
        {
            get { return weight; }
            set
            {
                if (value >= 0) weight = value;
                else throw new ArgumentException("Weight cannot be negative");
            }
        }

        public virtual bool CanLiveWithOtherAnimals
        {
            get { return canLiveWithOtherAnimals; }
            set { canLiveWithOtherAnimals = value; }
        }

        public override string ToString() => $"Name: {name}, Weight: {weight}, Type: {type}, Food Type: {foodType}, Daily Food Intake: {dailyFoodIntake}, Monthly Food Intake: {monthlyFoodIntake}, Can Live with Other Animals: {canLiveWithOtherAnimals}";

        public virtual string ExtraInfo() => $"HashCode: {GetHashCode()}, Equals: {Equals(this)}";

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + (name?.GetHashCode() ?? 0);
            hash = hash * 23 + weight.GetHashCode();
            hash = hash * 23 + foodType.GetHashCode();
            hash = hash * 23 + monthlyFoodIntake.GetHashCode();
            hash = hash * 23 + dailyFoodIntake.GetHashCode();
            hash = hash * 23 + canLiveWithOtherAnimals.GetHashCode();
            return hash;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Animal other)
            {
                return name == other.name &&
                       weight == other.weight &&
                       foodType == other.foodType &&
                       dailyFoodIntake == other.dailyFoodIntake &&
                       monthlyFoodIntake == other.monthlyFoodIntake &&
                       canLiveWithOtherAnimals == other.canLiveWithOtherAnimals;
            }
            return false;
        }
    }
}