﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo.InheritanceAnimals
{
    public class Dog : Animal
    {
        public void Bark() 
        {
            Console.WriteLine("I am baaarking...");
        }
    }
}
