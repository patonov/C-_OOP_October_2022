using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.planets;

        public void AddItem(IPlanet model)
        {
            this.planets.Add(model);
        }

        public IPlanet FindByName(string name) => this.planets.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name) => this.planets.Remove(this.planets.FirstOrDefault(x => x.GetType().Name == name));
    }
}
