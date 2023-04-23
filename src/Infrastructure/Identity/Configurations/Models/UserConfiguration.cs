using Domain;
using Domain.Identity;
using Identity.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configurations.Models;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(DatabaseTableName.User, DatabaseSchema.SecuritySchema);

        builder.Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Firstname)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(t => t.Lastname)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(t => t.CellNumber)
            .HasMaxLength(14);

        builder.Property(t => t.Address)
            .HasMaxLength(512);

        builder.Property(t => t.Image)
          .HasMaxLength(256);

        builder.Property(t => t.IsActive)
         .IsRequired();

        builder.Property(t => t.CreatedDate)
           .IsRequired();

        builder.Property(t => t.CreatedBy)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(t => t.UpdatedBy)
          .HasMaxLength(256);

    }
}

