using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnionApp.Persistance.Configurations
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder.HasKey(x => new { x.UserId, x.RoleId });
            builder.ToTable("UserRoles");

            builder.HasData(
                  new IdentityUserRole<int>()
                  {
                      UserId = 1,
                      RoleId = 1
                  },
                  new IdentityUserRole<int>()
                  {
                      UserId = 2,
                      RoleId = 2
                  }
                );
        }
    }
}
