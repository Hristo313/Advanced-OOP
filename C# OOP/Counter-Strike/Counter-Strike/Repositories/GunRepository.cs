namespace Counter_Strike.Repositories
{
    using Counter_Strike.Models.Guns;
    using Counter_Strike.Models.Guns.Contracts;
    using Counter_Strike.Repositories.Contracts;
    using Counter_Strike.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GunRepository : IRepository<IGun>
    {
        private readonly ICollection<IGun> guns;

        public GunRepository()
        {
            guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models 
            => (IReadOnlyCollection<IGun>)this.guns;

        public void Add(IGun gun)
        {
            if(gun == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            guns.Add(gun);
        }

        public bool Remove(IGun gun)
            => guns.Remove(gun);     

        public IGun FindByName(string name)     
            => guns.FirstOrDefault(g => g.Name == name);           
    }
}
