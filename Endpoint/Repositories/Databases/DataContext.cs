using Microsoft.EntityFrameworkCore;

using Endpoint.Models.Data;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Emit;

namespace Endpoint.Repositories.Databases
{
    public class DataContext : DbContext
    {
        public DbSet<Table> Tables { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
