using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : IVehicle
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumtion { get; set; }
        public int TankCapacity { get; set; }

        private double AditionalLitersPerKm = 0.9;

        public Car(double fuelQuantity,double fuelConsumtion,int tankCapacity)
        {

            FuelConsumtion = fuelConsumtion;
            FuelQuantity = fuelQuantity;
            TankCapacity = tankCapacity;
        }

        public void Drive(double distance)
        {
            if (distance * (AditionalLitersPerKm + FuelConsumtion) <= FuelQuantity)
            {
                FuelQuantity -= distance * (AditionalLitersPerKm + FuelConsumtion);
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
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
