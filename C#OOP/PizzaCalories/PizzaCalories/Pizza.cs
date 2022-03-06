using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            this.toppings = new List<Topping>();
        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length == 0 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough Dough { get; private set; }
        public List<Topping> Toppings { get; set; }
        public double Calories => this.Dough.Calories + this.toppings.Sum(x=>x.Calories); 
        public void AddTopping(Topping topping)
        {
            if (toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
        }
    }
}
