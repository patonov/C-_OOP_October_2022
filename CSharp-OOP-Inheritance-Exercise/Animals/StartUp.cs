using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            
            while (true)
            {
                var line1 = Console.ReadLine();

                if (line1 == "Beast!")
                {
                    break;
                }
                var line2 = Console.ReadLine().Split().ToArray();
                int age = int.Parse(line2[1]);

                try
                {
                    if (line1 == nameof(Dog))
                    {
                        IAnimal animal = new Dog(line2[0], age, line2[2]);
                        Console.WriteLine(animal.ToString());
                    }
                    else if (line1 == nameof(Cat))
                    {
                        IAnimal animal = new Cat(line2[0], age, line2[2]);
                        Console.WriteLine(animal.ToString());
                    }
                    else if (line1 == nameof(Frog))
                    {
                        IAnimal animal = new Frog(line2[0], age, line2[2]);
                        Console.WriteLine(animal.ToString());
                    }
                    else if (line1 == nameof(Kitten))
                    {
                        IAnimal animal = new Kitten(line2[0], age);
                        Console.WriteLine(animal.ToString());
                    }
                    else if (line1 == nameof(Tomcat))
                    {
                        IAnimal animal = new Tomcat(line2[0], age);
                        Console.WriteLine(animal.ToString());
                    }
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
                       
            
        }
    }
}
