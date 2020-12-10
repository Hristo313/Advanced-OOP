namespace Counter_Strike.Repositories.Contracts
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(T player);

        bool Remove(T player);

        T FindByName(string name);
    }
}
