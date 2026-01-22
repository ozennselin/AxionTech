using Data.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Infrastructure.Configuration;

public class OrderItemConfiguration:IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItem", schema: "dbo");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        // BaseEntity’den gelen ama burada kullanılmayan alan
        

        builder.Property(x => x.OrderId).IsRequired(true);
        builder.Property(x => x.ProductId).IsRequired(true);

        builder.Property(x => x.Quantity).IsRequired(true);

        builder.Property(x => x.UnitPrice)
               .IsRequired(true)
               .HasPrecision(18, 2);

        builder.Property(x => x.LineTotal)
               .IsRequired(true)
               .HasPrecision(18, 2);

        builder.Property(x => x.CreateDate).IsRequired(true);
        builder.Property(x => x.CreatorId).IsRequired(true);
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.UpdaterId).IsRequired(false);

       
        builder.HasOne(x => x.Order)
               .WithMany(o => o.OrderItems)
               .HasForeignKey(x => x.OrderId)
               .OnDelete(DeleteBehavior.Cascade);

    
        builder.HasOne(x => x.Product)
               .WithMany()
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
