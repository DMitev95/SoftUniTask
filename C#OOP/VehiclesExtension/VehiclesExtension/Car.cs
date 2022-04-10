using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Car : Vehivcle
    {
        private static readonly double BonusFuel = 0.9;
        public Car(double fuelQuantity, double fuelPerKm, double tankCApacity) : base(fuelQuantity, fuelPerKm + BonusFuel , tankCApacity)
        {
            this.FuelQuantity = fuelQuantity > tankCApacity ? 0 : fuelQuantity;
            this.FuelPerKm = fuelPerKm + BonusFuel;
            this.TankCApacity = tankCApacity;
        }
        public override void Drive(double distance)
        {
            if (FuelPerKm * distance > FuelQuantity)
            {
                Console.WriteLine("Car needs refueling");
            }
            else
            {
                FuelQuantity -= FuelPerKm * distance;
                Console.WriteLine($"Car travelled {distance} km");
            }
        }
        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.FuelQuantity + liters > this.TankCApacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += liters;
            }
        }
    }
}
