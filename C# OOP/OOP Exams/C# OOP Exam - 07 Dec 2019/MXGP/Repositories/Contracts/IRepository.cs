namespace MXGP.Repositories.Contracts.Models
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        T GetByName(string name);

        IReadOnlyCollection<T> GetAll();

        void Add(T model);

        bool Remove(T model);
    }
}
