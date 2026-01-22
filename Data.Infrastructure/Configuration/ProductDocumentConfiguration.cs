using Data.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Infrastructure.Configuration;

public class ProductDocumentConfiguration:IEntityTypeConfiguration<ProductDocument>
{
    public void Configure(EntityTypeBuilder<ProductDocument> builder)
    {
        builder.ToTable("ProductDocument", schema: "dbo");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.ProductId).IsRequired(true);
        builder.Property(x => x.Url).IsRequired(true).HasMaxLength(500);
        builder.Property(x => x.FileName).IsRequired(true).HasMaxLength(250);
        builder.Property(x => x.FileType).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.CreateDate).IsRequired(true);
        builder.Property(x => x.CreatorId).IsRequired(true);
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.UpdaterId).IsRequired(false);

        builder.HasOne(x => x.Product)
               .WithMany(p => p.ProductDocuments)
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
