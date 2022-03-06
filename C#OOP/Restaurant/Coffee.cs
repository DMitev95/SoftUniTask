using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee :HotBeverage
    {
        

        public Coffee(string name, double caffeine) : base(name, CoffeePrice,CoffeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        private const double CoffeMilliliters = 50;
        private const decimal CoffeePrice = 3.50m;
        public double Caffeine { get ; set ; }
    }
}
