using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {

        private readonly DecorationRepository decorations;
        private readonly ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new HashSet<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                aquariums.Add(new FreshwaterAquarium(aquariumName));

            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquariums.Add(new SaltwaterAquarium(aquariumName));
            }
            else
            {
                return string.Format(ExceptionMessages.InvalidAquariumType);
            }
            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                decorations.Add(new Ornament());
            }
            else if (decorationType == "Plant")
            {
                decorations.Add(new Plant());
            }
            else
            {
                return string.Format(ExceptionMessages.InvalidAquariumType);
            }
            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            if (fishType == "FreshwaterFish")
            {
                var fish = new FreshwaterFish(fishName, fishSpecies, price);

                if (aquarium.GetType().Name == nameof(SaltwaterAquarium))
                {
                    return String.Format(OutputMessages.UnsuitableWater);
                }
                else
                {
                    aquarium.AddFish(fish);
                    return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
            }
            else if (fishType == "SaltwaterFish")
            {
                var fish = new FreshwaterFish(fishName, fishSpecies, price);
                if (aquariumName.GetType().Name == nameof(FreshwaterAquarium))
                {
                    return String.Format(OutputMessages.UnsuitableWater);
                }
                else
                {
                    aquarium.AddFish(fish);
                    return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            var decValue = aquarium.Decorations.Sum(x => x.Price);
            var fishValue = aquarium.Fish.Sum(x => x.Price);
            decimal value = decValue + fishValue;

            return String.Format(OutputMessages.AquariumValue, aquarium.Name, value);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();
            var fishCount = aquarium.Fish.Count();

            return String.Format(OutputMessages.FishFed, fishCount);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            var decoration = decorations.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration,decorationType));
            }
            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);

            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquarium.Name);

        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
