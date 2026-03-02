using Data.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Infrastructure.Configuration;

public class ProductPictureConfiguration:IEntityTypeConfiguration<ProductPicture>
{
    public void Configure(EntityTypeBuilder<ProductPicture> builder)
    {
        builder.ToTable("ProductPicture", schema: "dbo");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();       
        builder.Property(x => x.ProductId).IsRequired(true);
        builder.Property(x => x.Url).IsRequired(true).HasMaxLength(500);
        builder.Property(x => x.IsMain).IsRequired(true);
        builder.Property(x => x.DisplayOrder).IsRequired(true);
        builder.Property(x => x.CreateDate).IsRequired(true);
        builder.Property(x => x.CreatorId).IsRequired(true);
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.UpdaterId).IsRequired(false);
        builder.HasOne(x => x.Product)
               .WithMany(p => p.ProductPictures)
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
