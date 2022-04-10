using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Bus : Vehivcle
    {
        private static readonly double busBonustFuel = 1.4;
        public Bus(double fuelQuantity, double fuelPerKm, double tankCApacity) : base(fuelQuantity, fuelPerKm, tankCApacity)
        {
            this.FuelQuantity = fuelQuantity > tankCApacity ? 0 : fuelQuantity;
            this.FuelPerKm = fuelPerKm;
            this.TankCApacity = tankCApacity;
        }
        public override void Drive(double distance)
        {
            if ((FuelPerKm + busBonustFuel) * distance > FuelQuantity)
            {
                Console.WriteLine("Bus needs refueling");
            }
            else
            {
                FuelQuantity -= (FuelPerKm + busBonustFuel) * distance;
                Console.WriteLine($"Bus travelled {distance} km");
            }
        }
        public override void DriveEmpty(double distance)
        {
            if (FuelPerKm * distance > FuelQuantity)
            {
                Console.WriteLine("Bus needs refueling");
            }
            else
            {
                FuelQuantity -= FuelPerKm * distance;
                Console.WriteLine($"Bus travelled {distance} km");
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
