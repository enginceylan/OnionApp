using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionApp.Domain.Entities;

namespace OnionApp.Persistance.Configurations
{
    public class OrderDetailConfiguration:BaseEntityTypeConfiguration<OrderDetail,object>, IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Ignore(x => x.Id);

            builder.HasKey(x => new {x.OrderId , x.ProductId}); // composite key tanımı

            builder.Property(e => e.Quantity)
                   .HasDefaultValue((short)1);

            builder.Property(e => e.UnitPrice)
                   .HasColumnType("money");

            builder.HasOne(d => d.Product)
                   .WithMany(p => p.OrderDetails)
                   .HasForeignKey(d => d.ProductId)
                   //.OnDelete(DeleteBehavior.SetNull)
                   .HasConstraintName("FK_OrderDetails_Products");

            builder.HasOne(d => d.Order)
                   .WithMany(p => p.OrderDetails)
                   .HasForeignKey(d => d.OrderId)
                   //.OnDelete(DeleteBehavior.SetNull)
                   .HasConstraintName("FK_OrderDetails_Orders");
        }
    }
}
