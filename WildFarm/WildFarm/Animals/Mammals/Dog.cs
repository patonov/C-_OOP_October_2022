using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double BasicWeightModifier = 0.40;

        private static HashSet<string> dogAllowedFood = new HashSet<string>
        {
            nameof(Meat)
        };

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, dogAllowedFood, BasicWeightModifier, livingRegion)
        {

        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
