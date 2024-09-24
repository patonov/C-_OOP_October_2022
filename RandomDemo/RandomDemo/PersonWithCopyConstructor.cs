using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class PersonWithCopyConstructor
    {
        public PersonWithCopyConstructor(PersonWithCopyConstructor person) 
        { 
            this.Name = person.Name;
            this.Age = person.Age;
            this.Weight = person.Weight;
        }

        public PersonWithCopyConstructor(string name, int age, double weight)
        { 
            this.Name = name;
            this.Age = age;
            this.Weight = weight;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Weight { get; set; }

    }
}
