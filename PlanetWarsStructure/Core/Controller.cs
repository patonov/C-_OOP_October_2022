using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (this.planets.FindByName(planetName) == default)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (unitTypeName != nameof(AnonymousImpactUnit) && unitTypeName != nameof(SpaceForces) && unitTypeName != nameof(StormTroopers))
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }
            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }

            IMilitaryUnit unit;

            if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else
            {
                unit = new AnonymousImpactUnit();
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);
            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (this.planets.FindByName(planetName) == default)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (weaponTypeName != nameof(BioChemicalWeapon) && weaponTypeName != nameof(NuclearWeapon) && weaponTypeName != nameof(SpaceMissiles))
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }
            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
            }

            IWeapon weapon;

            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else
            {
                weapon = new SpaceMissiles(destructionLevel);
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return $"{planetName} purchased {weaponTypeName}!";
        }

        public string CreatePlanet(string name, double budget)
        {
            if (this.planets.FindByName(name) != null)
            {
                return $"Planet {name} is already added!";
            }
            else
            {
                Planet planet = new Planet(name, budget);
                this.planets.AddItem(planet);
                return $"Successfully added Planet: {name}";
            }
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in this.planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        { 
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);

            if (firstPlanet != default && secondPlanet != default)
            {
                double firstPlanetHalfBudget = firstPlanet.Budget / 2;
                double secondPlanetHalfBudget = secondPlanet.Budget / 2;

                double firstCalculatedValue = firstPlanet.Army.Sum(x => x.Cost) +
                                                firstPlanet.Weapons.Sum(y => y.Price);

                double secondCalculatedValue = secondPlanet.Army.Sum(x => x.Cost) +
                                                secondPlanet.Weapons.Sum(y => y.Price);

                double firstPowerRatio = firstPlanet.MilitaryPower;
                double secondPowerRatio = secondPlanet.MilitaryPower;

                bool firstHasNuclear = firstPlanet.Weapons
                    .Any(w => w.GetType().Name == nameof(NuclearWeapon));

                bool secondHasNuclear = secondPlanet.Weapons
                    .Any(w => w.GetType().Name == nameof(NuclearWeapon));

                var firstNuclear = firstPlanet.Weapons
                    .FirstOrDefault(w => w.GetType().Name == nameof(NuclearWeapon));
                var secondNuclear = secondPlanet.Weapons
                    .FirstOrDefault(w => w.GetType().Name == nameof(NuclearWeapon));

                if (firstPowerRatio > secondPowerRatio)
                {
                    firstPlanet.Spend(firstPlanetHalfBudget);
                    firstPlanet.Profit(secondPlanetHalfBudget);
                    firstPlanet.Profit(secondCalculatedValue);

                    planets.RemoveItem(secondPlanet.Name);
                    return $"{planetOne} destructed {planetTwo}!";
                }
                else if (firstPowerRatio < secondPowerRatio)
                {
                    secondPlanet.Spend(secondPlanetHalfBudget);
                    secondPlanet.Profit(firstPlanetHalfBudget);
                    secondPlanet.Profit(firstCalculatedValue);

                    planets.RemoveItem(firstPlanet.Name);
                    return $"{planetTwo} destructed {planetOne}!";
                }
                else
                {
                    if (firstNuclear != null && secondNuclear != null)
                    {
                        firstPlanet.Spend(firstPlanetHalfBudget);
                        secondPlanet.Spend(secondPlanetHalfBudget);
                        return "The only winners from the war are the ones who supply the bullets and the bandages!";

                    }
                    else if (firstNuclear != null)
                    {
                        firstPlanet.Spend(firstPlanetHalfBudget);
                        firstPlanet.Profit(secondPlanetHalfBudget);
                        firstPlanet.Profit(secondCalculatedValue);

                        planets.RemoveItem(secondPlanet.Name);
                        return $"{planetOne} destructed {planetTwo}!";
                    }
                    else if (secondNuclear != null)
                    {
                        secondPlanet.Spend(secondPlanetHalfBudget);
                        secondPlanet.Profit(firstPlanetHalfBudget);
                        secondPlanet.Profit(firstCalculatedValue);

                        planets.RemoveItem(firstPlanet.Name);
                        return $"{planetTwo} destructed {planetOne}!";
                    }
                    else
                    {
                        firstPlanet.Spend(firstPlanetHalfBudget);
                        secondPlanet.Spend(secondPlanetHalfBudget);
                        return "The only winners from the war are the ones who supply the bullets and the bandages!";
                    }
                }
            }
            else
            {
                return "The only winners from the war are the ones who supply the bullets and the bandages!";
            }
        }
        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new ArgumentException($"Planet {planetName} does not exist!");
            }
            else if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException("No units available for upgrade!");
            }
            else
            {
                double specializeCost = 1.25;
                planet.TrainArmy();
                planet.Spend(specializeCost);

                return $"{planetName} has upgraded its forces!";
            }
        }
    }
}
