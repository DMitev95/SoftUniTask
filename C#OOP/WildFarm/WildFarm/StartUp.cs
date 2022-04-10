using System;
using System.Collections.Generic;

namespace WildFarm
{
    internal class StartUp
    {

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Animal> animals = new List<Animal>();
            while (input != "End")
            {
                try
                {
                    string[] animalInfo = input.Split();
                    string[] foodInfo = Console.ReadLine().Split();
                    string type = animalInfo[0];
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    Animal animal = null;
                    if (type == "Cat" || type == "Tiger")
                    {
                        string living = animalInfo[3];
                        string breed = animalInfo[4];
                        if (type == "Cat")
                        {
                            animal = new Cat(name, weight, living, breed);
                        }
                        else
                        {
                            animal = new Tiger(name, weight, living, breed);
                        }
                    }
                    else if (type == "Hen" || type == "Owl")
                    {
                        double wing = double.Parse(animalInfo[3]);
                        if (type == "Hen")
                        {
                            animal = new Hen(name, weight, wing);
                        }
                        else
                        {
                            animal = new Owl(name, weight, wing);
                        }
                    }
                    else
                    {
                        string living = animalInfo[3];
                        if (type == "Dog")
                        {
                            animal = new Dog(name, weight, living);
                        }
                        else
                        {
                            animal = new Mouse(name, weight, living);
                        }
                    }
                    Console.WriteLine(animal.ProduceSound());
                    animals.Add(animal);
                    string food = foodInfo[0];
                    int quantity = int.Parse(foodInfo[1]);
                    IFood fod = null;
                    if (food == "Vegetable")
                    {
                        fod = new Vegetable(quantity);
                    }
                    else if (food == "Fruit")
                    {
                        fod = new Fruit(quantity);
                    }
                    else if (food == "Meat")
                    {
                        fod = new Meat(quantity);
                    }
                    else if (food == "Seeds")
                    {
                        fod = new Seeds(quantity);
                    }
                    animal.Eat(fod);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                input = Console.ReadLine();
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
