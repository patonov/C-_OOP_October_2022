using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo.RawData
{
    public class Tyre
    {
        private double pressure;
        private int age;

        public Tyre(double pressure, int age) 
        { 
            this.Pressure = pressure;
            this.Age = age;
        }

        public double Pressure { get; private set; }

        public int Age { get; private set; }
    }
}
