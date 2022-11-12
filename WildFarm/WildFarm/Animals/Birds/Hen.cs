﻿using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double BasicWeightModifier = 0.35;

        private static HashSet<string> henAllowedFood = new HashSet<string>
        {
            nameof(Meat),
            nameof(Vegetable),
            nameof(Fruit),
            nameof(Seeds)
        };

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, henAllowedFood, BasicWeightModifier, wingSize)
        {


        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
