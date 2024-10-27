using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo.RawData
{
    public class Cargo
    {
        private int cargoWeight;
        private string cargoType;

        public Cargo(int cargoWeight, string cargoType)
        { 
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;
        }

        public int CargoWeight 
        { 
            get => this.cargoWeight;
            private set
            { 
            this.cargoWeight = value;
            }
        }

        public string CargoType 
        { 
            get => this.cargoType;
            private set
            { 
            this.cargoType = value;
            }
        }
    }
}
