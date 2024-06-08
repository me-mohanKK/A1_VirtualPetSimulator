using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1_VirtualPetSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("Welcome to the Virtual Pet Simulator!");
                Console.WriteLine("Choose a pet type:");
                Console.WriteLine("1. Cat");
                Console.WriteLine("2. Dog");
                Console.WriteLine("3. Rabbit");
                Console.Write("Enter the pet type you love: ");
                string petTypeChoice = Console.ReadLine();
                string petType;

                switch (petTypeChoice)
                {
                    case "1":
                        petType = "Cat";
                        break;
                    case "2":
                        petType = "Dog";
                        break;
                    case "3":
                        petType = "Rabbit";
                        break;
                    default:
                        petType = "Unknown";
                        break;
                }

                // Verify if pet type is valid
                if (petType == "Unknown")
                {
                    Console.WriteLine("Invalid choice. Please restart the application and choose a valid pet type.");
                    return;
                }

                Console.Write("How would you like to call your pet  : ");
                string petName = Console.ReadLine();

                Pet pet = new Pet(petName, petType);
                Console.WriteLine($"Welcome, {pet.Name} the {pet.Type}!");

                bool quit = false;

                //Displaying Main Menu
                while (quit)
                {
                    Console.WriteLine("\nMain Menu:");
                    Console.WriteLine("1. Feed");
                    Console.WriteLine("2. Play");
                    Console.WriteLine("3. Rest");
                    Console.WriteLine("4. Status");
                    Console.WriteLine("5. Time Passes");
                    Console.WriteLine("6. Exit");
                    Console.Write("Choose an action (1-6): ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            pet.Feed();
                            break;
                        case "2":
                            pet.Play();
                            break;
                        case "3":
                            pet.Rest();
                            break;
                        case "4":
                            pet.ShowStatus();
                            break;
                        case "5":
                            pet.TimePasses();
                            break;
                        case "6":
                            quit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }

                    // Method to show the Status
                    pet.ShowStatus();
                }

                Console.WriteLine("Thank you for playing the Virtual Pet Simulator. Goodbye!");
            }
        }

        class Pet
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public int Hunger { get; set; } = 5;
            public int Happiness { get; set; } = 5;
            public int Health { get; set; } = 5;

            public Pet(string name, string type)
            {
                Name = name;
                Type = type;
            }

            public void Feed()
            {
                Hunger = Math.Max(Hunger - 2, 0);
                Health = Math.Min(Health + 1, 10);
                Console.WriteLine($"{Name} has been fed. Hunger decreased, Health increased.");
            }

            public void Play()
            {
                Happiness = Math.Min(Happiness + 2, 10);
                Hunger = Math.Min(Hunger + 1, 10);
                Console.WriteLine($"{Name} played. Happiness increased, Hunger increased.");
            }

            public void Rest()
            {
                Health = Math.Min(Health + 2, 10);
                Happiness = Math.Max(Happiness - 1, 0);
                Console.WriteLine($"{Name} rested. Health increased, Happiness decreased.");
            }

            public void ShowStatus()
            {
                Console.WriteLine($"{Name}'s Status:\nHunger: {Hunger}/10\nHappiness: {Happiness}/10\nHealth: {Health}/10");
                if (Hunger >= 8)
                    Console.WriteLine($"{Name} is very hungry!");
                if (Happiness <= 2)
                    Console.WriteLine($"{Name} is very unhappy!");
                if (Health <= 2)
                    Console.WriteLine($"{Name} is in poor health!");
            }

            public void TimePasses()
            {
                Hunger = Math.Min(Hunger + 1, 10);
                Happiness = Math.Max(Happiness - 1, 0);
                if (Hunger >= 8 || Happiness <= 2)
                    Health = Math.Max(Health - 1, 0);
            }
        }
    }
}