namespace AquaShop.Models.Fishes
{
    public class SaltwaterFish : Fish
    {
        private const int SALTWATER_FISH_SIZE = 5;

        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = SALTWATER_FISH_SIZE;
        }

        public override void Eat()
        {
            this.Size += 2;
        }
    }
}
