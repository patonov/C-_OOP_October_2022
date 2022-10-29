using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public class SpaceForces : MilitaryUnit
    {
        public const double costs = 11;

        public SpaceForces() : base(costs)
        {
        }
    }
}
