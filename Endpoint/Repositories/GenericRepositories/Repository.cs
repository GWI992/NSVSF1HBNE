using Endpoint.Models.Interfaces;
using Endpoint.Repositories.Interfaces;
using Endpoint.Repositories.Databases;

namespace Endpoint.Repositories.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : class, IHasId
    {
        protected DataContext ctx;
        public Repository(DataContext ctx)
        {
            this.ctx = ctx;
        }
        public virtual void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public virtual IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public virtual T Read(string id)
        {
            return ctx.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public virtual void Update(string id, T item)
        {
            var old = this.Read(id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }

        public virtual void Delete(string id)
        {
            T item = this.Read(id);
            if (item != null)
            {
                ctx.Set<T>().Remove(item);
                ctx.SaveChanges();
            }
        }

    }

}
