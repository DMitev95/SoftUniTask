using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiding
{
    public class Engine
    {
        private List<BaseHero> hero;
        public Engine()
        {
            hero = new List<BaseHero>();
        }
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            while (hero.Count != n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                FillingRaidGroup(name, type);
            }
            long bosPower = long.Parse(Console.ReadLine());
            long totalPower = hero.Sum(x => x.Power);
            foreach (BaseHero hero in hero)
            {
                Console.WriteLine(hero.CastAbility());
            }
            if (bosPower > totalPower)
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }
        }

        private void FillingRaidGroup(string name, string type)
        {
            BaseHero heros = null;
            if (type == "Paladin")
            {
                heros = new Paladin(name);
            }
            else if (type == "Druid")
            {
                heros = new Druid(name);
            }
            else if (type == "Rogue")
            {
                heros = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                heros = new Warrior(name);
            }
            else
            {
                Console.WriteLine("Invalid hero!");
            }
            if (heros != null)
            {
                this.hero.Add(heros);
            }
        }
    }
}
