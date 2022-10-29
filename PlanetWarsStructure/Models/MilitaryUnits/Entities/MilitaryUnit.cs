using PlanetWars.Models.MilitaryUnits.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;

        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.enduranceLevel = 1;
        }

        public double Cost
        {
            get => this.cost;
            set { this.cost = value; }
        }

        public int EnduranceLevel
        {
            get => this.enduranceLevel;            
        }

        public void IncreaseEndurance()
        {
            if (this.EnduranceLevel > 20)
            {
                this.enduranceLevel = 20;
                throw new ArgumentException("Endurance level cannot exceed 20 power points.");
            }
            this.enduranceLevel++;
        }
    }
}
