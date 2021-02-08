namespace AquaShop.Models.Aquariums
{
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fishes.Contracts;
    using AquaShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private readonly ICollection<IDecoration> decorations;
        private readonly ICollection<IFish> fishes;

        private Aquarium()
        {
            this.decorations = new List<IDecoration>();
            this.fishes = new List<IFish>();
        }

        protected Aquarium(string name, int capacity)
            : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort
            => this.Decorations.Sum(c => c.Comfort);

        public IReadOnlyCollection<IDecoration> Decorations
            => (IReadOnlyCollection<IDecoration>)this.decorations;

        public IReadOnlyCollection<IFish> Fish
            => (IReadOnlyCollection<IFish>)this.fishes;

        public void AddFish(IFish fish)
        {
            if (this.Capacity <= this.fishes.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            else
            {
                this.fishes.Add(fish);
            }
        }

        public bool RemoveFish(IFish fish)
            => this.fishes.Remove(fish);


        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fish in this.fishes)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name})")
              .AppendLine($"Fish: {(this.fishes.Any() ? string.Join(", ", this.fishes.Select(n => n.Name)) : "none")}")
              .AppendLine($"Decorations: {this.decorations.Count}")
              .AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}
