namespace AquaShop.Models.Fishes
{
    public class FreshwaterFish : Fish
    {
        private const int FRESHWATER_FISH_SIZE = 3;

        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = FRESHWATER_FISH_SIZE;
        }

        public override void Eat()
        {
            this.Size += 3;
        }
    }
}
