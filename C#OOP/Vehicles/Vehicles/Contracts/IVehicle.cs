using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public  interface IVehicle
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumtion { get; set; }
        public int TankCapacity { get; set; }
        public void Drive(double distace);
        public void Refuel(double liters);
    }
}
