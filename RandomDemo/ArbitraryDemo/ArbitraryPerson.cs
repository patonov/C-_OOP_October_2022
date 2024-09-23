using RandomDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ArbitraryDemo
{
    public class ArbitraryPerson : Person
    {
        private double veryNice;

        public ArbitraryPerson()
        {
            veryNice = this.Proportion;
        }
                
    }

    file class StupidPerson : ArbitraryPerson
    {
        public StupidPerson() { }

        public string? Description { get; set; }
    }
}
