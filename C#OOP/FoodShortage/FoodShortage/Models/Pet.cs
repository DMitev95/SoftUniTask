using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Pet : IBirthday
    {
        public Pet(string birthday, string name)
        {
            Birthday = birthday;
            Name = name;
        }

        public string Birthday { get; set; }
        public string Name { get; private set; }
    }
}
