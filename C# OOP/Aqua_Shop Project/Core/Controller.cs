namespace AquaShop.Core
{
    using AquaShop.Core.Contracts;
    using AquaShop.IO;
    using AquaShop.Models.Aquariums;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fishes;
    using AquaShop.Models.Fishes.Contracts;
    using AquaShop.Repositories;
    using AquaShop.Repositories.Contracts;
    using AquaShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private readonly IRepository<IDecoration> decorations;
        private readonly ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(aquarium);

            string result = string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            return result;
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else if (decorationType == nameof(Plant))
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);

            string result = string.Format(OutputMessages.SuccessfullyAdded, decorationType);
            return result;
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations.FindByType(decorationType);
            IAquarium aquarium = GetAquarium(aquariumName);

            if (decoration == null)
            {
                string exceptionMessage = string.Format(ExceptionMessages.InexistentDecoration, decorationType);
                throw new InvalidOperationException(exceptionMessage);
            }

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            string result = string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
            return result;
        }

        private IAquarium GetAquarium(string aquariumName)
        {
            return this.aquariums.FirstOrDefault(n => n.Name == aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = GetAquarium(aquariumName);

            IFish fish = null;

            if(fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);

                if(aquarium.GetType().Name == nameof(FreshwaterAquarium))
                {
                    aquarium.AddFish(fish);
                    string result = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                    return result;
                }
            }
            else if(fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);

                if (aquarium.GetType().Name == nameof(SaltwaterAquarium))
                {
                    aquarium.AddFish(fish);
                    string result = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                    return result;
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            return OutputMessages.UnsuitableWater;
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = GetAquarium(aquariumName);

            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
            }

            string result = string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
            return result;
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = GetAquarium(aquariumName);

            decimal aquariumValue = 0;

            foreach (var direction in aquarium.Decorations)
            {
                aquariumValue += direction.Price;
            }

            foreach (var fish in aquarium.Fish)
            {
                aquariumValue += fish.Price;
            }

            string result = string.Format(OutputMessages.AquariumValue, aquariumName, aquariumValue);
            return result;
        }       

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
