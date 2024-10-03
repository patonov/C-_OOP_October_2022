using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class Card
    {       
        public required string Face { get; set; }

        public required string Suit { get; set; }

        public void Print()
        {
            Console.WriteLine($"{this.Face} {this.Suit}");
        }
    }
}
