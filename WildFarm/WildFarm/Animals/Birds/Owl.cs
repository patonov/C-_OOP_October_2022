using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        private const double BasicWeightModifier = 0.25;

        private static HashSet<string> owlAllowedFood = new HashSet<string>
        {
            nameof(Meat)
        };

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, owlAllowedFood, BasicWeightModifier, wingSize)
        {


        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
