using Domain.Identity;
using Identity.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configurations.Models;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable(DatabaseTableName.Permission, DatabaseSchema.SecuritySchema);
        builder.Property(t => t.PermissionId)
           .IsRequired()
           .ValueGeneratedOnAdd();

        builder.Property(t => t.Title)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(t => t.Url)
          .HasMaxLength(256)
          .IsRequired();

        builder.Property(t => t.Description)
          .HasMaxLength(512);
    }
}

