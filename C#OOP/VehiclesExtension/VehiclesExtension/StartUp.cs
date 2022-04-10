using System;

namespace VehiclesExtension
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Vehivcle car = (Car)CreateNewVehicle();
            Vehivcle truck = (Truck)CreateNewVehicle();
            Vehivcle bus = (Bus)CreateNewVehicle();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();
                if (commands[0] == "Drive")
                {
                    if (commands[1] == "Car")
                    {
                        car.Drive(double.Parse(commands[2]));
                    }
                    else if (commands[1] == "Truck")
                    {
                        truck.Drive(double.Parse(commands[2]));
                    }
                    else if (commands[1] == "Bus")
                    {
                        bus.Drive(double.Parse(commands[2]));
                    }
                }
                else if (commands[0] == "Refuel")
                {
                    if (commands[1] == "Car")
                    {
                        car.Refuel(double.Parse(commands[2]));
                    }
                    else if (commands[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(commands[2]));
                    }
                    else if (commands[1] == "Bus")
                    {
                        bus.Refuel(double.Parse(commands[2]));
                    }
                }
                else if (commands[0] == "DriveEmpty")
                {
                    bus.DriveEmpty(double.Parse(commands[2]));
                }

            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }

        private static Vehivcle CreateNewVehicle()
        {
            string[] infos = Console.ReadLine().Split();
            double fuelQuontity = double.Parse(infos[1]);
            double fuelPerKm = double.Parse(infos[2]);
            double tankCapacity = int.Parse(infos[3]);
            if (infos[0] == "Car")
            {
                return new Car(fuelQuontity, fuelPerKm, tankCapacity);
            }
            else if (infos[0] == "Truck")
            {
                return new Truck(fuelQuontity, fuelPerKm, tankCapacity);
            }
            else
            {
                return new Bus(fuelQuontity, fuelPerKm, tankCapacity);
            }
        }
    }
}
