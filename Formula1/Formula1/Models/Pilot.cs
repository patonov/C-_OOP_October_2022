using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private bool canRace;
        private IFormulaOneCar car;
        private int numberOfWins;

        public Pilot(string fullName)
        {
            this.FullName = fullName;
            this.canRace = false;
            this.numberOfWins = 0;
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid pilot name: { value }.");
                }
                this.fullName = value;
            }        
        }

        public IFormulaOneCar Car
        {
            get => this.car;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Pilot car can not be null.");
                }
                this.car = value;
            }
        }

        public int NumberOfWins
        {
            get => this.numberOfWins;
        }

        public bool CanRace => this.canRace;

        public void AddCar(IFormulaOneCar car)
        {
            this.car = car;
            this.canRace = true;
        }

        public void WinRace()
        {
            this.numberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
