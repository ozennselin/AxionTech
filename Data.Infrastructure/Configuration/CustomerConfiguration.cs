using Data.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Infrastructure.Configuration;

public class CustomerConfiguration:IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer", "dbo");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.CustomerTypeId).IsRequired(true);
        builder.Property(x => x.Email).IsRequired(true).HasMaxLength(250);
        builder.Property(x => x.PhoneNumber).IsRequired(false).HasMaxLength(30);
        builder.Property(x => x.AddressLine1).IsRequired(true).HasMaxLength(250);
        builder.Property(x => x.AddressLine2).IsRequired(false).HasMaxLength(250);
        builder.Property(x => x.City).IsRequired(true).HasMaxLength(100);
        builder.Property(x => x.Country).IsRequired(true).HasMaxLength(100);
        builder.Property(x => x.PostalCode).IsRequired(true).HasMaxLength(20);
        builder.Property(x => x.FirstName).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.TCKN).IsRequired(false).HasMaxLength(11);
        builder.Property(x => x.CompanyName).IsRequired(false).HasMaxLength(200);
        builder.Property(x => x.TaxOffice).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.TaxNumber).IsRequired(false).HasMaxLength(20);
        builder.Property(x => x.IsActive).IsRequired(true);
        builder.Property(x => x.CreateDate).IsRequired(true);
        builder.Property(x => x.CreatorId).IsRequired(true);
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.UpdaterId).IsRequired(false);
        builder.HasIndex(x => x.Email).IsUnique();
    }
}
