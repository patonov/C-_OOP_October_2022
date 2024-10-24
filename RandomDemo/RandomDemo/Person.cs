using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class Person
    {
        private string name;
        private int age;
        private int weight;

        public Person() 
        { 
        
        }

        public Person(int a) : this()
        {
            this.Age = a;
        }

        public Person(double b) : this(18)
        {
            this.Weight = b;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        } 

        public int Age 
        { 
            get => this.age;
            set
            {
                if (value <= 0 || value > 100) 
                {
                    throw new ArgumentException("Ne staa taka moi chovek");
                }
                this.age = value;
            }
        }

        public double Weight { get; set; } = 60.00;

        protected internal double Proportion { get => Age/Weight;  }
                

    }
}
