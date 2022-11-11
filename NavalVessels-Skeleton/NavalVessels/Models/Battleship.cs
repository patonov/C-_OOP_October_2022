using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode;

        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, 300)
        {
            this.sonarMode = false;
        }

        public bool SonarMode
        {
            get => this.sonarMode;
            private set
            {
                this.sonarMode = value;
            }
        }

        public void ToggleSonarMode()
        {
            if (this.SonarMode == false)
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }

        public override string ToString()
        {
            string result = base.ToString();
            if (this.SonarMode == true)
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
