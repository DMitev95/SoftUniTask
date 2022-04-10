using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Truck : Vehivcle
    {
        static readonly double bonustFuel = 1.6;
        public Truck(double fuelQuantity, double fuelPerKm, double tankCApacity) : base(fuelQuantity, fuelPerKm + bonustFuel , tankCApacity)
        {
            this.FuelQuantity = fuelQuantity > tankCApacity ? 0 : fuelQuantity;
            this.FuelPerKm = fuelPerKm + bonustFuel;
            this.TankCApacity = tankCApacity;
        }
        public override void Drive(double distance)
        {
            if (FuelPerKm * distance > FuelQuantity)
            {
                Console.WriteLine("Truck needs refueling");
            }
            else
            {
                FuelQuantity -= FuelPerKm * distance;
                Console.WriteLine($"Truck travelled {distance} km");
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
                this.FuelQuantity += liters * 0.95;
            }
        }
    }
}
