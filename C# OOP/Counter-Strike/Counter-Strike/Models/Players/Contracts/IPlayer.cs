namespace Counter_Strike.Models.Players.Contracts
{
    using Counter_Strike.Models.Guns;
    using Counter_Strike.Models.Guns.Contracts;

    public interface IPlayer
    {
        string Username { get; }

        int Health { get; }

        int Armor { get; }

        bool IsAlive { get; }

        IGun Gun { get; }

        void TakeDamage(int points);
    }
}
