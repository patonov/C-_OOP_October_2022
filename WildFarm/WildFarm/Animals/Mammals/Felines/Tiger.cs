using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double BasicWeightModifier = 1;

        private static HashSet<string> tigerAllowedFood = new HashSet<string>
        {
            nameof(Meat)
        };

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, tigerAllowedFood, BasicWeightModifier, livingRegion, breed)
        {


        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
