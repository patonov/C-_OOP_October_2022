using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NavalVessels.Core
{
    public class Controller : IController
    {        
        
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = this.captains.FirstOrDefault(x => x.FullName == selectedCaptainName);

            if (captain == null)
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }

            IVessel vessel = this.vessels.FindByName(selectedVesselName);

            if (vessel == null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }
            
            if (vessel.Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }

            vessel.Captain = captain;
            captain.AddVessel(vessel);
            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var firstVessel = this.vessels.FindByName(attackingVesselName);
            var secondVessel = this.vessels.FindByName(defendingVesselName);

            if (firstVessel == null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }

            if (secondVessel == null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }
            
            if (firstVessel.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }

            firstVessel.Attack(secondVessel);
            firstVessel.Captain.IncreaseCombatExperience();
            secondVessel.Captain.IncreaseCombatExperience();
            return $"Vessel {secondVessel.Name} was attacked by vessel {firstVessel.Name} - current armor thickness: {secondVessel.ArmorThickness}.";
        }

        public string CaptainReport(string captainFullName)
        {
            string result = string.Empty;
            foreach (var ves in this.vessels.Models)
            {
                if (ves.Captain.FullName == captainFullName)
                {
                    result = ves.Captain.Report();
                }
            }
            return result;
        }

        public string HireCaptain(string fullName)
        {
            if (this.captains.FirstOrDefault(x => x.FullName == fullName) != null)
            {
                return $"Captain {fullName} is already hired.";
            }

            ICaptain captain = new Captain(fullName);
            this.captains.Add(captain);
            return $"Captain {fullName} is hired.";
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (this.vessels.FindByName(name) != null)
            {
                return $"{vesselType} vessel {name} is already manufactured.";
            }
            if (vesselType != nameof(Battleship) && vesselType != nameof(Submarine))
            {
                return "Invalid vessel type.";
            }
            IVessel vessel;

            if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            this.vessels.Add(vessel);
            return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = this.vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }
            else
            {
                vessel.RepairVessel();
                return $"Vessel {vesselName} was repaired.";
            }
        }

        public string ToggleSpecialMode(string vesselName)
        {

            var vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }
            else
            {
                if (vessel.GetType().Name == nameof(Battleship))
                {
                    Battleship battleship = (Battleship)this.vessels.FindByName(vesselName);
                    battleship.ToggleSonarMode();
                    return $"Battleship {vesselName} toggled sonar mode.";
                }
                else
                {
                    Submarine submarine = (Submarine)this.vessels.FindByName(vesselName);
                    submarine.ToggleSubmergeMode();
                    return $"Submarine {vesselName} toggled submerge mode.";
                }
            }
            
        }

        public string VesselReport(string vesselName)
        {
            string info = string.Empty;

            foreach (var ves in this.vessels.Models)
            {
                if (ves.Name == vesselName)
                {
                    info = ves.ToString();
                }
            }
            return info;
        }
    }
}
