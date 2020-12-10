namespace Counter_Strike.Repositories
{
    using Counter_Strike.Models.Players.Contracts;
    using Counter_Strike.Repositories.Contracts;
    using Counter_Strike.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly ICollection<IPlayer> players;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models
            => (IReadOnlyCollection<IPlayer>)this.players;

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            players.Add(player);
        }

        public bool Remove(IPlayer player)
            => players.Remove(player);

        public IPlayer FindByName(string name)
            => players.FirstOrDefault(p => p.Username == name);
    }
}
