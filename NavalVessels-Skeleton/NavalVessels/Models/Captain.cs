using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {

        private string fullName;
        private List<IVessel> vessels;
        private int combatExperience;

        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.combatExperience = 0;
            this.vessels = new List<IVessel>();
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Captain full name cannot be null or empty string.");
                }
                this.fullName = value;
            }        
        }

        public int CombatExperience { get; private set; }

        public ICollection<IVessel> Vessels => this.vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            }
            this.vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            foreach (var ves in this.Vessels)
            {
                if (ves.Targets.Count > 0)
                {
                    this.CombatExperience += 10; 
                }
            }
        }

        public string Report()
        {
            if (this.Vessels.Count == 0)
            {
                return $"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.";
            }
            else
            { 
            string result = $"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels."
                    + Environment.NewLine;
                foreach (var ves in this.Vessels)
                {
                    result = result + ves.ToString() + Environment.NewLine;
                }
                return result.Trim();
            }
        }
    }
}
