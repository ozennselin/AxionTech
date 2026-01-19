using Data.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Infrastructure.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        //builder.ToTable("Category", schema: "dbo");
        builder.HasKey(k => k.Id);//PK yapar
        builder.Property(k => k.Id).UseIdentityColumn();//Identity yapar ,1 ile başlar,1 er artar
        builder.Property(k => k.Name).IsRequired(true).HasMaxLength(250);
        builder.Property(k => k.Description).IsRequired(false).HasMaxLength(600);
        builder.Property(k => k.CreateDate).IsRequired(true);
        builder.Property(k => k.CreatorId).IsRequired(true);

        //bağlantılar
    }
}