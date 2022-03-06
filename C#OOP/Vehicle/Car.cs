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
        }
    }
}
