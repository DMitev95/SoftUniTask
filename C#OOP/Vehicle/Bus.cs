using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Bus : Vehivcle
    {
        private static readonly double busBonustFuel = 1.4;
        public Bus(double fuelQuantity, double fuelPerKm, double tankCApacity) : base(fuelQuantity, fuelPerKm + busBonustFuel, tankCApacity)
        {

        }
    }
}
