using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class Garage 
    {
        private List<Car> cars;

        public Garage(params Car[] cars) 
        { 
            this.cars = cars.ToList();
        }

        public void Sort()
        { 
            CarComparer carComparer = new CarComparer();
            this.cars.Sort(carComparer);
        }

        public class CarComparer : IComparer<Car>
        {
            public int Compare(Car x, Car y)
            {
                var result = x.Make.CompareTo(y.Make);

                if (result == 0)
                    result = x.Year.CompareTo(y.Year);

                return result;
            }
        }
    }
}
