using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionApp.Domain.Entities.Identity;

namespace OnionApp.Persistance.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("Users");

            builder.Ignore(x => x.AccessFailedCount);
            builder.Ignore(x => x.LockoutEnabled);
            builder.Ignore(x => x.LockoutEnd);
            builder.Ignore(x => x.PhoneNumber);
            builder.Ignore(x => x.PhoneNumberConfirmed);
            builder.Ignore(x => x.TwoFactorEnabled);


            // aşağıdaki kullanıcılar için şifre : 12345
            builder.HasData(
                    new AppUser()
                    {
                        Id = 1,
                        UserName = "admin",
                        NormalizedUserName = "ADMIN",
                        Email = "admin@gmail.com",
                        NormalizedEmail="ADMIN@GMAIL.COM",
                        FirstName = "Admin",
                        LastName = "AdminLast",
                        CreatedBy = "System",
                        Created = new DateTime(2023, 10, 01),
                        PasswordHash = "AQAAAAIAAYagAAAAENhzA4xMIh27qb169+gZDzSe+RN8QC4M9vh3/J/+yycGyd/XMrlJaG7m7Gjrr07ikw==",
                        SecurityStamp = "044D36DC-A5C6-4A55-878A-8EB6E4C52C33",
                        ConcurrencyStamp = "11111111-1111-1111-1111-111111111111" // sabit!
                    },
                    new AppUser()
                     {
                         Id = 2,
                         UserName = "user",
                         NormalizedUserName = "USER",
                         Email = "user@gmail.com",
                        NormalizedEmail = "USER@GMAIL.COM",
                        FirstName = "User",
                         LastName = "UserLast",
                         CreatedBy = "System",
                         Created = new DateTime(2023, 10, 01),
                         PasswordHash = "AQAAAAIAAYagAAAAENhzA4xMIh27qb169+gZDzSe+RN8QC4M9vh3/J/+yycGyd/XMrlJaG7m7Gjrr07ikw==",
                         SecurityStamp = "2410D000-094A-4614-BE71-06E814C3D47E",
                        ConcurrencyStamp = "22222222-2222-2222-2222-222222222222" // sabit!
                    }
             );
        }
    }
}
