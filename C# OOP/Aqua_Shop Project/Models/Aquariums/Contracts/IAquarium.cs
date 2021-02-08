namespace AquaShop.Models.Aquariums.Contracts
{
    using System.Collections.Generic;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fishes.Contracts;  

    public interface IAquarium
    {
        string Name { get; }

        int Capacity { get; }

        int Comfort { get; }

        IReadOnlyCollection<IDecoration> Decorations { get; }

        IReadOnlyCollection<IFish> Fish { get; }

        void AddFish(IFish fish);

        bool RemoveFish(IFish fish);

        void AddDecoration(IDecoration decoration);

        void Feed();

        string GetInfo();
    }
}
