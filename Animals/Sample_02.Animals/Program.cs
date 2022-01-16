using System;
using System.Collections.Generic;

namespace Sample_02_Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            var zoo = new Zoo();
            Console.WriteLine("Press CTRL+C to exit.");

            while (true)
            {
                zoo.Update();
                Console.WriteLine("Which animal would you like to feed?");
                string input = Console.ReadLine();
                zoo.Feed(input, 3);
            }
        }

    }

    class Animal
    {
        public Animal(string name, string type, int healthPoints, int food)
        {
            Name = name;
            Type = type;
            HealthPoints = healthPoints;
            Food = food;
        }
        public string Name { get; }
        public string Type { get; }
        public int HealthPoints { get; set; }
        public int Food { get; set; }

        public void Update()
        {
            if (HealthPoints <= 0) return;
            Food--;
            if (HealthPoints > 0)
            {
                Console.WriteLine(Name + "is starving.");
            }
            else
            {
                Console.WriteLine(Name + "starved to death.");
                HealthPoints = 0;
            }
            Food = 0;
        }
        public void Eat(int amount)
        {
            Food += amount;
        }
    }

    class Zoo
    {
        private readonly List<Animal> animals;

        public Zoo()
        {
            animals = new List<Animal>
            {
                new Animal("Lion", "Mammal", 200, 9),
                new Animal("Bear", "Mammal", 300, 10),
                new Animal("Giraffe", "Mammal", 100, 7),
                new Animal("Panda", "Mammal", 100, 4),
                new Animal("Elephant", "Mammal", 400, 5),
                new Animal("Cat", "Mammal", 50, 6),
                new Animal("Fish", "Aquarium", 10, 3),
            };
        }

        public void Update()
        {
            foreach (var animal in animals)
            {
                animal.Update();
            }
        }
        public void Feed(string name, int amount)
        {
            Animal animal = FindAnimalBy(name);
            if (animal != null)
            {
                animal.Eat(amount);
            }
        }

        private Animal FindAnimalBy(string name)
        {
            foreach (var animal in animals)
            {
                if (animal.Name.ToLower() == name.ToLower())
                {
                    return animal;
                }
            }

            return null;
        }
    }
}