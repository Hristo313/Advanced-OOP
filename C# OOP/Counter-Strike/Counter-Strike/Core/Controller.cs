namespace Counter_Strike.Core
{
    using Counter_Strike.Core.Contracts;
    using Counter_Strike.Models.Guns;
    using Counter_Strike.Models.Guns.Contracts;
    using Counter_Strike.Models.Maps;
    using Counter_Strike.Models.Maps.Contracts;
    using Counter_Strike.Models.Players;
    using Counter_Strike.Models.Players.Contracts;
    using Counter_Strike.Repositories;
    using Counter_Strike.Repositories.Contracts;
    using Counter_Strike.Utilities.Messages;
    using System;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private readonly IRepository<IGun> guns;
        private readonly IRepository<IPlayer> players;
        private readonly IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;

            if (type == nameof(Pistol))
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == nameof(Rafle))
            {
                gun = new Rafle(name, bulletsCount);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            this.guns.Add(gun);

            string message = string.Format(OutputMessages.SuccessfullyAddedGun, name);
            return message;
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            var gun = this.guns.FindByName(gunName);

            if (gun == null)
            {
                throw new AggregateException(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player = null;

            if (type == nameof(Terrorist))
            {
                player = new Terrorist(username, health, armor, gun);
            }
            else if (type == nameof(CounterTerrorist))
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            this.players.Add(player);

            string message = string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
            return message;
        }

        public string Report()
        {
            var players = this.players.Models
                 .OrderBy(t => t.GetType().Name)
                 .ThenByDescending(h => h.Health)
                 .ThenBy(u => u.Username)
                 .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var player in players)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            var allPlayers = this.players.Models.ToList();

            return this.map.Start(allPlayers);
        }
    }
}
