using Data.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Infrastructure.Configuration;

public class CartItemConfiguration:IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("CartItem", schema: "dbo");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.CartId).IsRequired(true);
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

        builder.HasOne(x => x.Cart)
            .WithMany(c => c.CartItems)
            .HasForeignKey(x => x.CartId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
