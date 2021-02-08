namespace Counter_Strike.Models.Maps.Contracts
{
    using Counter_Strike.Models.Players.Contracts;
    using System.Collections.Generic;

    public interface IMap
    {
        string Start(ICollection<IPlayer> players);
    }
}
