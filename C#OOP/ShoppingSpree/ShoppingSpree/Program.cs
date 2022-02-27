using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] persons = Console.ReadLine().Split(new char[] { ';', '=' },StringSplitOptions.RemoveEmptyEntries).ToArray();
                string[] products = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                List<Person> person = new List<Person>();
                for (int i = 0; i < persons.Length; i += 2)
                {
                    string name = persons[i];
                    double price = double.Parse(persons[i + 1]);
                    Person person1 = null;
                    person1 = new Person(name, price);
                    person.Add(person1);
                }
                List<Product> product = new List<Product>();
                for (int i = 0; i < products.Length; i += 2)
                {
                    string name = products[i];
                    double price = double.Parse(products[i + 1]);
                    Product product1 = null;
                    product1 = new Product(name, price);
                    product.Add(product1);
                }
                string commands = Console.ReadLine();
                while (commands != "END")
                {
                    string[] cmd = commands.Split();
                    string name = cmd[0];
                    string prod = cmd[1];
                    Person human = person.FirstOrDefault(person => person.Name == name);
                    Product food = product.FirstOrDefault(product => product.Name == prod);
                    if (human.Money >= food.Cost)
                    {
                        Console.WriteLine($"{human.Name} bought {food.Name}");
                        human.Products.Add(food);
                        human.Money -= food.Cost;
                    }
                    else
                    {
                        Console.WriteLine($"{human.Name} can't afford {food.Name}");
                    }
                    commands = Console.ReadLine();
                }
                foreach (Person per in person)
                {
                    Console.WriteLine($"{per}");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
