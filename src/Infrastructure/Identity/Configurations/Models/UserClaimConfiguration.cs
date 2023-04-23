using Domain.Identity;
using Identity.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configurations.Models;

public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable(DatabaseTableName.UserClaim, DatabaseSchema.SecuritySchema);

        builder.Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(t => t.ClaimType)
            .HasMaxLength(512);

        builder.Property(t => t.ClaimValue)
             .HasMaxLength(256);

    }
}

