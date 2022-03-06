using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public abstract class Vehivcle
    {
        private double tankCapacity;
        protected Vehivcle(double fuelQuantity, double fuelPerKm, double tankCApacity)
        {
            FuelQuantity = fuelQuantity;
            FuelPerKm = fuelPerKm;
            TankCApacity = tankCApacity;
        }

        public double FuelQuantity { get; set; }
        public double FuelPerKm { get; set; }
        public double TankCApacity
        {
            get { return this.tankCapacity; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Fuel must be a positive number");
                }
                this.tankCapacity = value;
            }
        }

        public string Drive(double distance)
        {
            if (distance * FuelPerKm > FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }
            FuelQuantity -= distance * FuelPerKm;
            return $"{this.GetType().Name} travelled {distance} km";
        }
        public virtual void Refuel(double liters)
        {
            if (FuelQuantity + liters > TankCApacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                FuelQuantity += liters;
            }    
        }
        public virtual string DriveEmpty(double distance)
        {
            if (distance * (FuelPerKm - 1.4) > FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }
            FuelQuantity -= distance * (FuelPerKm-1.4);
            return $"{this.GetType().Name} travelled {distance} km";
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
