using Data.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Infrastructure.Configuration;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        //builder.ToTable("Product",schema:"def");
        builder.ToTable("Product", schema: "dbo");
        //schema isimleri dbo, def, cnfg,set olabilir
        //builder.Property(k=>k.Id).IsRequired();//PK, Is Identity
        builder.HasKey(k => k.Id);//PK yapar
        builder.Property(k => k.Id).UseIdentityColumn();//Identity yapar ,1 ile başlar,1 er artar
        builder.Property(k => k.Name).IsRequired(true).HasMaxLength(250);
        builder.Property(k => k.Description).IsRequired(false).HasMaxLength(600);
        builder.Property(k => k.CategoryId).IsRequired(true);
        builder.Property(k => k.CreateDate).IsRequired(true);
        builder.Property(k => k.CreatorId).IsRequired(true);
        builder.Property(k => k.UpdateDate).IsRequired(false);
        builder.Property(k => k.UpdaterId).IsRequired(false);

    }
}
