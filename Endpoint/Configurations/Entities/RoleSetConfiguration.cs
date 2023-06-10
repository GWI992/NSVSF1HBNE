using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;

namespace Endpoint.Configurations.Entities
{
    public class RoleSetConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        private const string adminRoleId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
        private const string adminUserId = "9b100ee4-69ab-42b9-ae2f-31e1b33c462d";
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId,
                }
            );
        }
    }
}
