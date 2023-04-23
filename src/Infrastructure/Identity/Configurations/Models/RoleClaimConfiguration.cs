using Domain.Identity;
using Identity.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configurations.Models;

public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.ToTable(DatabaseTableName.RoleClaim, DatabaseSchema.SecuritySchema);

        builder.Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(t => t.ClaimType)
            .HasMaxLength(512);

        builder.Property(t => t.ClaimValue)
             .HasMaxLength(256);

    }
}

