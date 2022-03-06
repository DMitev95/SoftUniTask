using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirthdayCelebrations
{
    public class Engine
    {
        private List<IBirthday> bithdate;
        public Engine()
        {
            this.bithdate = new List<IBirthday>(); 
        }
        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] info = input.Split();
                CreateInfo(info);
                input = Console.ReadLine();
            }
            string birthYear = Console.ReadLine();
            string[] searchedBirthYears = this.bithdate.Where(x=>x.Birthday.Split("/").Last() == birthYear).Select(x=>x.Birthday).ToArray();
            foreach (string year in searchedBirthYears)
            {
                Console.WriteLine(year);
            }
        }

        private void CreateInfo(string[] info)
        {
            IBirthday birthday = null;
            string type = info[0];
            if (type == "Citizen")
            {
                birthday = new Citizen(info[1], int.Parse(info[2]), info[3], info[4]);
            }
            else if (type == "Pet")
            {
                birthday = new Pet(info[2],info[1]);
            }
            if (birthday != null)
            {
                this.bithdate.Add(birthday);
            }
        }
    }
}
