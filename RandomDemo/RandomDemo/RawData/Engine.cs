using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo.RawData
{
    public class Engine
    {
        private int engineSpeed;
        private int enginePower;

        public Engine(int engineSpeed, int enginePower)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }

        public int EngineSpeed 
        { 
            get => this.engineSpeed;
            private set
            { 
                this.engineSpeed = value;
            }
        }

        public int EnginePower 
        { 
            get => this.enginePower;
            private set
            { 
                this.enginePower = value;
            }
        }
    }
}
