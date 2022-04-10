using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public abstract class Vehivcle
    {
        protected Vehivcle(double fuelQuantity, double fuelPerKm, double tankCApacity)
        {
            this.FuelQuantity = fuelQuantity > tankCApacity ? 0 : fuelQuantity;
            FuelPerKm = fuelPerKm;
            TankCApacity = tankCApacity;
        }

        public double FuelQuantity { get; set; }
        public double FuelPerKm { get; set; }
        public double TankCApacity { get; set; }

        public virtual void Drive(double distance)
        {
        }
        public virtual void Refuel(double liters)
        { 
        }
        public virtual void DriveEmpty(double distance)
        {
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
