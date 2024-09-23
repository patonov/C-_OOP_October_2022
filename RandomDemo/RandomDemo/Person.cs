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

        public Person() 
        { 
        
        }

        //public Person(int a) : this()
        //{
        //    this.Age = a;
        //}

        //public Person(double b) : this(18)
        //{
        //    this.Wight = b;
        //}

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

        public int Age { get; set; }

        public double Weight { get; set; }

        protected internal double Proportion { get; set; }
                

    }
}
