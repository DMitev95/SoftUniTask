using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : IIdentifiable,IBirthday
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; set; }
        public string Birthday { get; set; }
    }
}
