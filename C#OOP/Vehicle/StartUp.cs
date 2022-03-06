using System;
using System.Text;

namespace VehiclesExtension
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Car car = (Car)CreateNewVehicle();
            Truck truck = (Truck)CreateNewVehicle();
            Bus bus = (Bus)CreateNewVehicle();
            StringBuilder sb = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();
                if (double.Parse(commands[2]) <= 0)
                {
                    Console.WriteLine("Fuel must be a positive number");
                }
                else
                {
                    if (commands[0] == "Drive")
                    {
                        if (commands[1] == "Car")
                        {
                           sb.AppendLine(car.Drive(double.Parse(commands[2])));
                           Console.WriteLine(sb.ToString().Trim());
                           sb.Clear(); 
                        }
                        else if (commands[1] == "Truck")
                        {
                            sb.AppendLine(truck.Drive(double.Parse(commands[2])));
                            Console.WriteLine(sb.ToString().Trim());
                            sb.Clear();
                        }
                        else if (commands[1] == "Bus")
                        {
                            sb.AppendLine(bus.Drive(double.Parse(commands[2])));
                            Console.WriteLine(sb.ToString().Trim());
                            sb.Clear();
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
                        sb.AppendLine(bus.DriveEmpty(double.Parse(commands[2])));
                        Console.WriteLine(sb.ToString().Trim());
                        sb.Clear();
                    }
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
            double tankCapacity = double.Parse(infos[3]); 
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
