using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode;

        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, 200)
        {
            this.submergeMode = false;
        }

        public bool SubmergeMode
        {
            get => this.submergeMode;
            private set
            {
                this.submergeMode = value;
            }
        }


        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode == false)
            {
                this.SubmergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.SubmergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }

        public override string ToString()
        {
            string result = base.ToString();
            if (this.SubmergeMode == true)
            {
                result = result + Environment.NewLine + " *Sonar mode: ON";
            }
            else
            {
                result = result + Environment.NewLine + " *Sonar mode: OFF";
            }
            return result.Trim();
        }
    }
}
