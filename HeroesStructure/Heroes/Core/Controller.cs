using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.FindByName(heroName);

            if (hero == null)
            {
                throw new InvalidOperationException($"Hero { heroName } does not exist.");
            }

            IWeapon weapon = weapons.FindByName(weaponName);

            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon { weaponName } does not exist.");
            }

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero { heroName } is well-armed.");
            }

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);

            return $"Hero { heroName } can participate in battle using a { hero.Weapon.GetType().Name.ToString().ToLower() }.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero = this.heroes.FindByName(name);

            if (hero != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }
            if (type != nameof(Knight) && type != nameof(Barbarian))
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            string result = string.Empty;

            if (type == nameof(Knight))
            {
                hero = new Knight(name, health, armour);
                this.heroes.Add(hero);
                result = $"Successfully added Sir {name} to the collection.";
            }
            if (type == nameof(Barbarian))
            {
                hero = new Barbarian(name, health, armour);
                this.heroes.Add(hero);
                result = $"Successfully added Barbarian {name} to the collection.";
            }
            return result;
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            type = type.ToLower();

            IWeapon weapon = this.weapons.FindByName(name);

            if (weapon != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }
            if (type != nameof(Mace).ToLower() && type != nameof(Claymore).ToLower())
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            string result = string.Empty;

            if (type != nameof(Mace).ToLower())
            {
                weapon = new Mace(name, durability);
                this.weapons.Add(weapon);
            }

            if (type != nameof(Claymore).ToLower())
            {
                weapon = new Claymore(name, durability);
                this.weapons.Add(weapon);
            }

            result = $"A { type.ToLower() } { name } is added to the collection.";
            return result;
        }

        public string HeroReport()
        {
            StringBuilder heroesInfo = new StringBuilder();

            foreach (IHero hero in this.heroes.Models.OrderBy(h => h.GetType().Name)
                                                .ThenByDescending(h => h.Health)
                                                .ThenBy(h => h.Name)
                                                .ToList())
            {
                heroesInfo.AppendLine($"{hero.GetType().Name}: {hero.Name}")
                          .AppendLine($"--Health: {hero.Health}")
                          .AppendLine($"--Armour: {hero.Armour}")
                          .AppendLine(hero.Weapon == null ? "--Weapon: Unarmed"
                                                          : $"--Weapon: {hero.Weapon.Name}");
            }

            return heroesInfo.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            Map map = new Map();

            string fightResult = map.Fight(heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList());

            return fightResult;
        }
    }
}
