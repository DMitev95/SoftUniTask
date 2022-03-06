using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Truck : Vehivcle
    {
        static readonly double bonustFuel = 1.6;
        public Truck(double fuelQuantity, double fuelPerKm, double tankCApacity) : base(fuelQuantity, fuelPerKm + bonustFuel, tankCApacity)
        {
        }
        public override void Refuel(double liters)
        {
            if (FuelQuantity + liters > TankCApacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                FuelQuantity += liters * 0.95;
            }
        }
    }
}
