using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        
        public Child(string name, int age) : base(name, age)
        {
        }

        public override int Age 
        { 
            get => base.Age;
            set 
            {
                if (this.Age > 15)
                {
                    throw new ArgumentException("The age of a child could not be above 15.");
                }
                base.Age = value;
            }
        }
    }
}
