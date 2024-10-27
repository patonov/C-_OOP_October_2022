using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo.RawData
{
    public class CargoCar
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private List<Tyre> tyres;

        public CargoCar(string model, Engine engine, Cargo cargo, List<Tyre> tyres)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tyres = tyres;
        }

        public string Model 
        { 
            get => this.model;
            private set
            { 
            this.model = value;
            }
        }

        public Engine Engine 
        {
            get => this.engine;
            private set
            { 
            this.engine = value;
            }
        }

        public Cargo Cargo 
        {
            get => this.cargo;
            private set
            { 
            this.cargo = value;
            }
        }

        public List<Tyre> Tyres 
        { 
            get => this.tyres;
            private set 
            { 
            this.tyres = value;
            }
        }




    }
}
