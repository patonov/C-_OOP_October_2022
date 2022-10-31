using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heroes;

        public HeroRepository()
        {
            heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => this.heroes;

        public void Add(IHero model)
        {
            this.heroes.Add(model);
        }

        public IHero FindByName(string name)
        {
            return this.heroes.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IHero model)
        {
            return this.heroes.Remove(model);
        }
    }
}
