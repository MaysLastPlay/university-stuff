using System;
using System.Collections.Generic;
using System.Text;
using Module3.enums;

namespace Module3.zoo.animals
{
    internal abstract class Animal
    {
        public string name { get; protected set; }
        public decimal weight { get; protected set; }
        public AnimalType type { get; protected set; }
        public FoodType foodType { get; protected set; }
        public double foodPerMonth { get; protected set; }
        public bool canLiveWithOtherAnimals { get; protected set; }

        protected Animal(string name, decimal weight, AnimalType type, FoodType foodType, double foodPerMonth, bool canLiveWithOtherAnimals)
        {
            this.name = name;
            this.weight = weight;
            this.type = type;
            this.foodType = foodType;
            this.foodPerMonth = foodPerMonth;
            this.canLiveWithOtherAnimals = canLiveWithOtherAnimals;
        }

        public abstract string SayMyName();
        public override string ToString() => $"Name: {name}, \nMessage: {SayMyName()}\nWeight: {weight}, \nType: {type}, \nFood Type: {foodType}, Food Per Month: {foodPerMonth} \nCan Live with Other Animals: {canLiveWithOtherAnimals}";

        public override int GetHashCode() => (name, weight, type).GetHashCode();

        public override bool Equals(object? obj)
        {
            if (obj is Animal other)
            {
                return name == other.name &&
                       weight == other.weight && type == other.type;
            }
            return false;
        }
    }
}
