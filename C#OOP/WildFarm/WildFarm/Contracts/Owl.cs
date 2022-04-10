using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        private const double Modifier = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }
        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                this.Weight += Modifier * food.Quantity;
                this.FoodEaten+= food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
        public override string ProduceSound() => "Hoot Hoot";
        
    }
}
