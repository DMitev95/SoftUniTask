using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : IBus
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumtion { get; set; }
        public int TankCapacity { get; set; }
        private double AditionalLitersPerKm = 1.4;

        public Bus(double fuelQuantity, double fuelConsumtion, int tankCapacity)
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
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
        public void DriveEmptyBus(double distance)
        {
            if (distance * FuelConsumtion <= FuelQuantity)
            {
                FuelQuantity -= distance * FuelConsumtion;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
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
