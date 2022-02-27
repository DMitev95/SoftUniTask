using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animal = new List<Animal>();
            string type = System.Console.ReadLine();
            while (type != "Beast!")
            {
                string[] command = System.Console.ReadLine().Split(" ");
                string name = command[0];
                int age = int.Parse(command[1]);
                string gender = command[2];
                if (age < 0)
                {
                    System.Console.WriteLine("Invalit input!");
                    type = System.Console.ReadLine();
                    continue;
                }
                Animal animals = null;
                if (type == "Cat")
                {
                    animals = new Cat(name, age, gender);
                    animal.Add(animals);
                }
                else if (type == "Dog")
                {
                    animals = new Dog(name, age, gender);
                    animal.Add(animals);
                }
                else if (type == "Frog")
                {
                    animals = new Frog(name, age, gender);
                    animal.Add(animals);
                }
                else if (type == "Kitten")
                {
                    animals = new Kitten(name, age);
                    animal.Add(animals);
                }
                else if (type == "Tomcat")
                {
                    animals = new Tomcat(name, age);
                    animal.Add(animals);
                }
                type = System.Console.ReadLine();
            }
            foreach(Animal anima in animal)
            {
                System.Console.WriteLine(anima.GetType().Name);
                System.Console.WriteLine($"{anima.Name} {anima.Age} {anima.Gender}");
                System.Console.WriteLine(anima.ProduceSound());
            }
        }
    }
}
