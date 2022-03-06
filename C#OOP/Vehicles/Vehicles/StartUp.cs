using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            IVehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]),int.Parse(carInfo[3]));
            string[] truckInfo = Console.ReadLine().Split();
            IVehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), int.Parse(truckInfo[3]));
            string[] busInfo = Console.ReadLine().Split();
            IBus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), int.Parse(busInfo[3]));
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                if (int.Parse(command[2]) > 0)
                {
                    if (command[0] == "Drive")
                    {
                        if (command[1] == "Car")
                        {
                            car.Drive(double.Parse(command[2]));
                        }
                        else if (command[1] == "Truck")
                        {
                            truck.Drive(double.Parse(command[2]));
                        }
                        else
                        {
                            bus.Drive(double.Parse(command[2]));
                        }

                    }
                    else if (command[0] == "Refuel")
                    {
                        if (command[1] == "Car")
                        {
                            car.Refuel(double.Parse(command[2]));
                        }
                        else if (command[1] == "Truck")
                        {
                            truck.Refuel(double.Parse(command[2]));
                        }
                        else
                        {
                            bus.Refuel(double.Parse(command[2]));
                        }
                    }
                    else if (command[0] == "DriveEmpty")
                    {
                        bus.DriveEmptyBus(double.Parse(command[2]));
                    }
                }
                else
                {
                    Console.WriteLine("Fuel must be a positive number");
                }
            }
            
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
