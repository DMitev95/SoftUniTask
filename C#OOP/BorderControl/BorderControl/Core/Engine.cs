using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl
{
    public class Engine
    {
        private List<IIdentifiable> repository;
        public Engine()
        {
            this.repository = new List<IIdentifiable>(); 
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
            string fakeId = Console.ReadLine();
            string[] fakeIdS = this.repository.Where(x=>x.Id.EndsWith(fakeId)).Select(x=>x.Id).ToArray();
            foreach (string id in fakeIdS)
            {
                Console.WriteLine(id);
            }
        }

        private void CreateInfo(string[] info)
        {
            IIdentifiable identifiable = null;
            if (info.Length == 3)
            {
                string name = info[0];
                int age = int.Parse(info[1]);
                string id = info[2];
                identifiable = new Citizen(name, age, id);
            }
            else
            {
                string model = info[0];
                string id = info[1];
                identifiable = new Robots(model, id);
            }
            this.repository.Add(identifiable);
        }
    }
}
