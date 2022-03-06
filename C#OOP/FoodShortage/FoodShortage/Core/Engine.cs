using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodShortage
{
    public class Engine
    {
        private List<IBuyer> buyers;
        public Engine()
        {
            this.buyers = new List<IBuyer>();

        }
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split();
                CreateInfo(personInfo);               
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                IBuyer newBuyer = BuyFood(command, buyers);
                newBuyer?.BuyFood();
                command = Console.ReadLine();
            }
            PrintTotalFood();
        }

        private void PrintTotalFood()
        {
            int totalFood = buyers.Sum(x=> x.Food);
            Console.WriteLine(totalFood);
        }

        private IBuyer BuyFood(string command, List<IBuyer> buyers)
        {
             IBuyer buyer = buyers.FirstOrDefault(x=> x.Name == command);
            return buyer;
        }

        private void CreateInfo(string[] info)
        {
            IBuyer buyer = null;
            if (info.Length == 4)
            {
                buyer = new Citizen(info[0], int.Parse(info[1]), info[2], info[3]);
            }
            else if (info.Length == 3)
            {
                buyer = new Rebel(info[0], int.Parse(info[1]), info[2]);
            }
            if (buyer != null)
            {
                this.buyers.Add(buyer);
            }
            
        }
    }
}
