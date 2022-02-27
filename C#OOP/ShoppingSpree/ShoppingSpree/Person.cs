using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        private List<Product> products;
        public Person()
        {
            products = new List<Product>();
        }

        public Person(string name, double price) : this()
        {
            Name = name;
            Money = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public double Money
        {
            get
            {
                return this.money;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public List<Product> Products { get => products; set => this.products = (List<Product>)value; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Products.Count > 0)
            {
                sb.AppendLine($"{Name} - {string.Join(", ", Products)}");
            }
            else
            {
                sb.AppendLine($"{Name} - Nothing bought");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
