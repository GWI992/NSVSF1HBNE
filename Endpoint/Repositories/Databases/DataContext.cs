using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Endpoint.Models.Data;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Emit;

namespace Endpoint.Repositories.Databases
{
    public class DataContext : IdentityDbContext<ApiUser>
    {
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>()
                .HasMany(c => c.Reservations)
                .WithOne(d => d.Table)
                .IsRequired();
            modelBuilder.Entity<Reservation>()
                .HasOne(d => d.Table)
                .WithMany(c => c.Reservations)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            base.OnModelCreating(modelBuilder);
        }

    }
}
