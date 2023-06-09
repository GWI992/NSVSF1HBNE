using Endpoint.Models.Data;
using Endpoint.Repositories.Databases;
using Endpoint.Repositories.GenericRepository;
using Endpoint.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoint.Repositories.ModelRepositories
{
    public class TableRepository : Repository<Table>, ITableRepository
    {
        public TableRepository(DataContext ctx) : base(ctx)
        {
        }
    }
}
