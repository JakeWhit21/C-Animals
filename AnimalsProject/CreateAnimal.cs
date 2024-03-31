namespace AnimalsProject;

using System;
using System.Collections.Generic;

    public class CreateAnimal
    {
        private readonly string REQUIRED_MSG = " is mandatory";
        private string animalType;
        private string animalName;
        private bool friendly;
        private int miceKilled;
        private int age;
        private Talkable talkableObject;
        private List<Talkable> zoo = new List<Talkable>();
        private readonly CommandLineOutputService output = new CommandLineOutputService();

        public CreateAnimal(List<Talkable> zoo)
        {
            this.zoo = zoo;
            AnimalPrompt();
            GatherAnimalInformation();
            CreateAnimalObject();
        }

        private void AnimalPrompt()
        {
            output.SimpleOutput("What type of animal would you like to create?");
            SetAnimalType(Console.ReadLine());
        }

        private void SetAnimalType(string animalType)
        {
            if (string.IsNullOrWhiteSpace(animalType))
            {
                throw new ArgumentException("Animal type" + REQUIRED_MSG);
            }
            this.animalType = animalType;
        }

        private void CreateAnimalObject()
        {
            if (animalType.Equals("Dog", StringComparison.OrdinalIgnoreCase))
            {
                this.talkableObject = new Dog(friendly, animalName);
            }
            else if (animalType.Equals("Cat", StringComparison.OrdinalIgnoreCase))
            {
                this.talkableObject = new Cat(miceKilled, animalName);
            }
            else if (animalType.Equals("Teacher", StringComparison.OrdinalIgnoreCase))
            {
                this.talkableObject = new Teacher(age, animalName);
            }
        }

        public Talkable GetAnimal()
        {
            return talkableObject;
        }

        private void GatherAnimalInformation()
        {
            if (animalType.Equals("Dog", StringComparison.OrdinalIgnoreCase))
            {
                output.SimpleOutput("Is this dog friendly? Type yes or no");
                SetFriendly(Console.ReadLine());
                output.SimpleOutput("What is the name for the dog?");
                SetAnimalName(Console.ReadLine());
            }
            else if (animalType.Equals("Cat", StringComparison.OrdinalIgnoreCase))
            {
                output.SimpleOutput("How many mice did this cat kill?");
                SetMiceKilled(int.Parse(Console.ReadLine()));
                output.SimpleOutput("What is the name for the cat?");
                SetAnimalName(Console.ReadLine());
            }
            else if (animalType.Equals("Teacher", StringComparison.OrdinalIgnoreCase))
            {
                output.SimpleOutput("What is the age of the teacher?");
                SetAge(int.Parse(Console.ReadLine()));
                output.SimpleOutput("What is the name for this teacher?");
                SetAnimalName(Console.ReadLine());
            }
        }

        private void SetFriendly(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Friendly" + REQUIRED_MSG);
            }
            if (input.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                friendly = true;
            }
            else if (input.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                friendly = false;
            }
        }

        private void SetAnimalName(string animalName)
        {
            if (string.IsNullOrWhiteSpace(animalName))
            {
                throw new ArgumentException("Animal name" + REQUIRED_MSG);
            }
            this.animalName = animalName;
        }

        private void SetMiceKilled(int miceKilled)
        {
            if (miceKilled < 0)
            {
                throw new ArgumentException("Mice killed cannot be less than 0");
            }
            this.miceKilled = miceKilled;
        }

        private void SetAge(int age)
        {
            if (age < 18)
            {
                throw new ArgumentException("Age cannot be less than 18 for teachers");
            }
            this.age = age;
        }
    }

