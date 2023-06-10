using Endpoint.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Endpoint.Configurations.Entities
{
    public class ApiUserConfiguration : IEntityTypeConfiguration<ApiUser>
    {
        public void Configure(EntityTypeBuilder<ApiUser> builder)
        {
            ApiUser admin = new ApiUser
            {
                Id = "9b100ee4-69ab-42b9-ae2f-31e1b33c462d",
                Email = "admin@admin.hu",
                UserName = "admin@admin.hu",
            };
            admin.NormalizedEmail = admin.Email.ToUpper();
            admin.NormalizedUserName = admin.UserName.ToUpper();
            admin.PasswordHash = new PasswordHasher<ApiUser>().HashPassword(admin, "9Aranyalma9");
            builder.HasData(
                admin
            );
        }
    }
}
