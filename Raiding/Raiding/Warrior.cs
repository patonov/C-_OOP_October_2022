using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        private const int BasicPower = 100;

        public Warrior(string name) : base(name, BasicPower)
        {


        }

        public override string CastAbility()
        {
            return $"{nameof(Warrior)} - {Name} hit for {Power} damage";
        }
    }
}
