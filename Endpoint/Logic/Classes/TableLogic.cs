using Endpoint.Logic.Exceptions;
using Endpoint.Logic.Interfaces;
using Endpoint.Models.Data;
using Endpoint.Repositories.Interfaces;

namespace Endpoint.Logic.Classes
{
    public class TableLogic : ILogic<Table, Table>
    {
        ITableRepository _repository;
        public TableLogic(ITableRepository repository)
        {
            this._repository = repository;
        }

        public void Create(Table item)
        {
            this._repository.Create(item);
        }

        public void Delete(string id)
        {
            this._repository.Delete(id);
        }

        public Table Read(string id)
        {
            Table table = this._repository.Read(id);
            if (table == null)
            {
                throw new EntityNotFoundException();
            }
            return table;
        }

        public IList<Table> ReadAll()
        {
            return this._repository.ReadAll()?.ToList();
        }

        public void Update(string id, Table item)
        {
            this.Read(id); // Check entity is exists
            this._repository.Update(id, item);
        }
    }
}
