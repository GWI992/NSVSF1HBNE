using Endpoint.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Endpoint.Configurations.Entities
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasData(
                new Table
                {
                    Name = "#1 Table",
                    Capacity = 2,
                },
                new Table
                {
                    Name = "#2 Table",
                    Capacity = 2,
                },
                new Table
                {
                    Name = "#3 Table",
                    Capacity = 2,
                },
                new Table
                {
                    Name = "#4 Table",
                    Capacity = 4,
                },
                new Table
                {
                    Name = "#5 Table",
                    Capacity = 4,
                },
                new Table
                {
                    Name = "#6 Table",
                    Capacity = 4,
                }
            );
        }
    }
}
