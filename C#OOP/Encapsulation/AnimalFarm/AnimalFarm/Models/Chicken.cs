using System;
namespace AnimalFarm.Models
{
    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;

        private string name;
        private int age;

        public Chicken(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                try
                {
                    if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException();
                    }
                    this.name = value;
                }
                catch(ArgumentException)
                {
                    Console.WriteLine("Name cannot be empty.");
                    Environment.Exit(0);
                }
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                try
                {
                    if (value >= MaxAge || value <= MinAge)
                    {
                        throw new ArgumentException();
                    }
                    this.age = value;
                }
                catch(ArgumentException)
                {
                    Console.WriteLine("Age should be between 0 and 15.");
                    Environment.Exit(0);
                }              
            }
        }

        public double ProductPerDay
        {
			get
			{				
				return this.CalculateProductPerDay();
			}
        }

        private double CalculateProductPerDay()
        {
            switch (this.Age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }
    }
}
