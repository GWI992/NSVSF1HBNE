using Endpoint.Models.Interfaces;

namespace Endpoint.Repositories.Interfaces
{
    public interface IRepository<T> where T : class, IHasId
    {
        IQueryable<T> ReadAll();
        T Read(string id);
        void Create(T item);
        void Update(string id, T item);
        void Delete(string id);
    }

}
