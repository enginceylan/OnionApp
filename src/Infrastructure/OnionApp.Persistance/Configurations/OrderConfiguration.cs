using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionApp.Domain.Entities;

namespace OnionApp.Persistance.Configurations
{
    public class OrderConfiguration : BaseEntityTypeConfiguration<Order, int>, IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Freight).HasColumnType("money");
        }
    }
}
