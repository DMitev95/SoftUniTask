using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : IVehicle
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumtion { get; set; }
        public int TankCapacity { get; set; }

        private double AditionalLitersPerKm = 1.6;

        public Truck(double fuelQuantity,double fuelConsumtion,int tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumtion = fuelConsumtion;
            TankCapacity = tankCapacity;
        }

        public void Drive(double distance)
        {
            if (distance * (AditionalLitersPerKm + FuelConsumtion) <= FuelQuantity)
            {
                FuelQuantity -= distance * (AditionalLitersPerKm + FuelConsumtion);
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }


        public void Refuel(double liters)
        {
            if (liters + FuelQuantity > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                FuelQuantity += liters;
            }
        }
    }
}
