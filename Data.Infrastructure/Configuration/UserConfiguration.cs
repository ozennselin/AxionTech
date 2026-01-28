using Data.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Infrastructure.Configuration;

public class UserConfiguration:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User>builder)
    {
        builder.ToTable("User", schema: "dbo");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.UserName).IsRequired(true).HasMaxLength(100);
        builder.Property(x => x.Email).IsRequired(true).HasMaxLength(250);
        builder.Property(x => x.PhoneNumber).IsRequired(false).HasMaxLength(30);
        builder.Property(x => x.PasswordHash).IsRequired(true).HasMaxLength(500);
        builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(100);
        builder.Property(x => x.DateOfBirth).IsRequired(false);
        builder.Property(x => x.Gender).IsRequired(false).HasMaxLength(20);
        builder.Property(x => x.IsActive).IsRequired(true);
        builder.Property(x => x.IsEmailConfirmed).IsRequired(true);       
        builder.Property(x => x.CreateDate).IsRequired(true);
        builder.Property(x => x.CreatorId).IsRequired(true);
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.UpdaterId).IsRequired(false);        
        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.UserName).IsUnique();
    }
}
