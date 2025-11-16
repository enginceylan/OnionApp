using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionApp.Domain.Common;
using OnionApp.Domain.Entities.Identity;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Persistance.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("Roles");

            builder.HasData(
                   new AppRole()
                   {
                       Id = 1,
                       Name = Roles.Admin.ToString(),
                       NormalizedName = Roles.Admin.ToString().ToUpper(new CultureInfo("en-US")),
                       CreatedBy = "System",
                       Created = new DateTime(2023, 10, 01),
                   },
                   new AppRole()
                   {
                       Id = 2,
                       Name = Roles.User.ToString(),
                       NormalizedName = Roles.User.ToString().ToUpper(new CultureInfo("en-US")),
                       CreatedBy = "System",
                       Created = new DateTime(2023, 10, 01),
                   }

                );
        }
    }
}
