using System;
using System.Collections.Generic;

namespace AnimalsProject;

class MainClass
{
    // private static readonly FileOutput outFile = new FileOutput("animals.txt");
    // private static readonly FileInput inFile = new FileInput("animals.txt");

    public static void Main(string[] args)
    {
        List<Talkable> zoo = new List<Talkable>();

        // Lines to Replace Begin Here
        string userInput;

        do
        {
            CreateAnimal userAnimal = new CreateAnimal(zoo);
            zoo.Add(userAnimal.GetAnimal());
            Console.WriteLine("Create another animal? Yes or No");
            userInput = Console.ReadLine();
        } while (userInput.Equals("yes", StringComparison.OrdinalIgnoreCase));
        // End Lines to Replace

        foreach (var thing in zoo)
        {
            PrintOut(thing);
        }

        // FileInput indata = new FileInput("animals.txt");
        string line;
        using (StreamReader indata = new StreamReader("animals.txt"))
        {
            while ((line = indata.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
        }
        
        
        
        
    }

    public static void PrintOut(Talkable p)
    {
        using (StreamWriter outFile = new StreamWriter("animals.txt", append:true))
        {
           Console.WriteLine(p.GetName() + " says=" + p.Talk());
                   outFile.WriteLine(p.GetName() + " | " + p.Talk());
                   
        }
        
        
    }
}