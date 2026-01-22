using Data.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Infrastructure.Configuration;

public class CustomerTypeConfiguration:IEntityTypeConfiguration<CustomerType>
{
    public void Configure(EntityTypeBuilder<CustomerType> builder)
    {
        builder.ToTable("CustomerType", "dbo");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(50);

        

        builder.Property(x => x.CreateDate).IsRequired(true);
        builder.Property(x => x.CreatorId).IsRequired(true);
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.UpdaterId).IsRequired(false);

      
        builder.HasData(
            new CustomerType { Id = 1, Name = "Individual", CreateDate = new DateTime(2026,01,22), CreatorId = 1 },
            new CustomerType { Id = 2, Name = "Corporate", CreateDate = new DateTime(2026, 01, 22), CreatorId = 1 }
        );
    }
}
