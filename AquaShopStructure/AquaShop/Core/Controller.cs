using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            IAquarium aquarium;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }

            this.aquariums.Add(aquarium);
            return $"Successfully added {aquarium.GetType().Name}.";
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != nameof(Ornament) && decorationType != nameof(Plant))
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            IDecoration decoration;

            if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else
            {
                decoration = new Plant();
            }
            this.decorations.Add(decoration);

            return $"Successfully added {decoration.GetType().Name}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            IAquarium targetAqua = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            IFish fish;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }

            if (fishType == "FreshwaterFish" && targetAqua.GetType().Name == "FreshwaterAquarium")
            {
                targetAqua.AddFish(fish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else if (fishType == "SaltwaterFish" && targetAqua.GetType().Name == "SaltwaterAquarium")
            {
                targetAqua.AddFish(fish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else
            { 
            return "Water not suitable.";
            }


        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium targetAqua = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            int count = targetAqua.Fish.Count;

            decimal sum = targetAqua.Fish.Sum(x => x.Price) + targetAqua.Decorations.Sum(x => x.Price);
            return $"The value of Aquarium {aquariumName} is {(sum):F2}.";
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium targetAqua = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            int count = targetAqua.Fish.Count;

            targetAqua.Feed();

            return $"Fish fed: {count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium targetAqua = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            IDecoration decor = this.decorations.FindByType(decorationType);

            if (decor == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            targetAqua.AddDecoration(decor);
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aqua in this.aquariums)
            {
                sb.AppendLine(aqua.GetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}
