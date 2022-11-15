using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronautRepository;
        private PlanetRepository planetRepository;
        private int exploredPlanetsCount = 0;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (type != nameof(Biologist) && type != nameof(Geodesist) && type != nameof(Meteorologist))
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }

            Astronaut astro;

            if (type == nameof(Biologist))
            {
                astro = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astro = new Geodesist(astronautName);
            }
            else
            {
                astro = new Meteorologist(astronautName);
            }
            this.astronautRepository.Add(astro);
            return $"Successfully added {astro.GetType().Name}: {astro.Name}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepository.Add(planet);

            return $"Successfully added Planet: {planetName}!"; 
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> suitableAstronauts = this.astronautRepository.Models.Where(x => x.Oxygen > 60).ToList();
            IPlanet planet = this.planetRepository.FindByName(planetName);
            Mission mission = new Mission();

            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }
            else
            {       
                mission.Explore(planet, suitableAstronauts);
                List<IAstronaut> deadAstronauts = suitableAstronauts.Where(x => x.Oxygen == 0).ToList();
                this.exploredPlanetsCount++;
                return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts.Count} dead astronauts!";
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{exploredPlanetsCount} planets were explored! \r\n" +
                $"Astronauts info:");
            sb.AppendLine();
            
            foreach (var astronaut in astronautRepository.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                if (astronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine("Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items:");
                    foreach (var item in astronaut.Bag.Items)
                    {
                        sb.Append(item);
                    }
                    sb.AppendLine();
                }
            }
            return sb.ToString().Trim();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astro = this.astronautRepository.FindByName(astronautName);
            if (astro == null)
            { 
            return $"Astronaut {astronautName} doesn't exists!";
            }
            this.astronautRepository.Remove(astro);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
