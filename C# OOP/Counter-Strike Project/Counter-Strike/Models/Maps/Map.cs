namespace Counter_Strike.Models.Maps
{
    using Counter_Strike.Models.Guns;
    using Counter_Strike.Models.Guns.Contracts;
    using Counter_Strike.Models.Maps.Contracts;
    using Counter_Strike.Models.Players;
    using Counter_Strike.Models.Players.Contracts;
    using Counter_Strike.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players.Where(p => p.GetType() == typeof(Terrorist)).ToList();
            var counterTerrorists = players.Where(p => p.GetType() == typeof(CounterTerrorist)).ToList();

            while (terrorists.Any(p => p.IsAlive)
                && counterTerrorists.Any(p => p.IsAlive))
            {
                foreach (var terrorist in terrorists.Where(p => p.IsAlive))
                {
                    foreach (var counterTerrorist in counterTerrorists.Where(p => p.IsAlive))
                    {
                        counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                    }
                }

                foreach (var counterTerrorist in counterTerrorists.Where(p => p.IsAlive))
                {
                    foreach (var terrorist in terrorists.Where(p => p.IsAlive))
                    {
                        terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                    }
                }
            }

            if (terrorists.Any(p => p.IsAlive))
            {
                return OutputMessages.TerroristWin;
            }
            else
            {
                return OutputMessages.CounterTerroristWin;
            }
        }
    }
}
