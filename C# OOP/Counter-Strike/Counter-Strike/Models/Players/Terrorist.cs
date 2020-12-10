namespace Counter_Strike.Models.Players
{
    using Counter_Strike.Models.Guns.Contracts;

    public class Terrorist : Player
    {
        public Terrorist(string username, int health, int armor, IGun gun) 
            : base(username, health, armor, gun)
        {
        }
    }
}
