using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            Quantity = quantity;
        }
        public int Quantity { get; }   
    }
}
