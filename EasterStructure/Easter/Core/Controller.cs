﻿using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        
        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }


        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType != "HappyBunny" && bunnyType != "SleepyBunny")
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }

            IBunny bunny;

            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else
            {
                bunny = new SleepyBunny(bunnyName);
            }
            this.bunnies.Add(bunny);
            return $"Successfully added {bunnyType} named {bunnyName}.";

        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye dye = new Dye(power);

            IBunny bunny = this.bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }

            bunny.AddDye(dye);
            return $"Successfully added dye with power {dye.Power} to bunny {bunny.Name}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            this.eggs.Add(egg);
            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = eggs.FindByName(eggName);

            IWorkshop workshop = new Workshop();

            List<IBunny> suitableBunnies = bunnies.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy).ToList();

            if (suitableBunnies.Any() == false)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            while (suitableBunnies.Any())
            {
                IBunny currentBunny = suitableBunnies.First();

                while (true)
                {
                    if (currentBunny.Energy == 0 || currentBunny.Dyes.All(x => x.IsFinished()))
                    {
                        suitableBunnies.Remove(currentBunny);
                        break;
                    }

                    workshop.Color(egg, currentBunny);

                    if (egg.IsDone())
                    {
                        break;
                    }
                }

                if (egg.IsDone())
                {
                    break;
                }
            }

            return $"Egg {eggName} is {(egg.IsDone() ? "done" : "not done")}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{eggs.Models.Count(x => x.IsDone())} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (IBunny bunny in bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count(x => !x.IsFinished())} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
