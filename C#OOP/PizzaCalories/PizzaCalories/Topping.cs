using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private Dictionary<string, double> toppincsType = new Dictionary<string, double>()
        {
            {"meat" , 1.2 },
            {"veggies" , 0.8},
            {"cheese" , 1.1 },
            {"sauce" , 0.9},
        };
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type 
        { 
            get
            {
                return this.type;
            }
            private set
            {
                if (!toppincsType.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }
        public double Weight 
        { 
            get
            {
                return (double)this.weight;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }
        public double Calories => 2 * Weight * toppincsType[Type.ToLower()];
    }
}
