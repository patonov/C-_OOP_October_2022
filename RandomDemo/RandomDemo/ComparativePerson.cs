﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class ComparativePerson : IComparable<ComparativePerson>
    {
        public ComparativePerson(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(ComparativePerson other)
        {
            var result = this.Name.CompareTo(other.Name);

            if (result == 0)
            { 
                result = this.Age.CompareTo(other.Age);
                if (result == 0)
                { 
                    result = this.Town.CompareTo(other.Town);
                }
            }

            return result;
        }
    }
}
