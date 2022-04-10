using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        private const double Modifier = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            this.Weight += Modifier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string ProduceSound() => "Cluck";


    }
}
