namespace AquaShop.Repositories
{
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly ICollection<IDecoration> decorations;

        public DecorationRepository()
        {
            this.decorations = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models
            => (IReadOnlyCollection<IDecoration>)this.decorations;

        public void Add(IDecoration model)
        {
            this.decorations.Add(model);
        }

        public IDecoration FindByType(string type)
           => this.decorations.FirstOrDefault(t => t.GetType().Name == type);

        public bool Remove(IDecoration model)
           => this.decorations.Remove(model);
    }
}
