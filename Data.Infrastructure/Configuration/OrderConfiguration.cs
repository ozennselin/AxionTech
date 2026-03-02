using Data.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Infrastructure.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order", schema: "dbo");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.OrderNo).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.OrderDate).IsRequired(true);
        builder.Property(x => x.TotalAmount).IsRequired(true).HasPrecision(18,2);
        builder.Property(x => x.Status).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.Address).IsRequired(false).HasMaxLength(500);
        builder.Property(x => x.UserId).IsRequired(true);
        builder.Property(x => x.CreateDate).IsRequired(true);
        builder.Property(x => x.CreatorId).IsRequired(true);
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.UpdaterId).IsRequired(false);
    }
}
