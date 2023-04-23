using Domain;
using Domain.Identity;
using Identity.Configurations.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Claims;

namespace Identity.Configurations.Entities;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var hasher = new PasswordHasher<User>();
        builder.ToTable(DatabaseTableName.User, DatabaseSchema.SecuritySchema);


        //seed data
        builder.HasData
            (
             new User
             {
                 Id = 1,
                 UserName = "admin",
                 Email = "admin@localhost.com",
                 Firstname = "System",
                 Lastname = "Admin",
                 IsActive = true,
                 CreatedBy = "System",
                 CreatedDate = DateTime.UtcNow,
                 Address = "address",
                 BirthDate = new DateTime(1988, 09, 10),
                 CellNumber = "09187108429",
                 Image = "Image",
                 PhoneNumber = "77245845",
                 NormalizedEmail = "ADMIN@LOCALHOST.COM",
                 NormalizedUserName = "admin",
                 PasswordHash = hasher.HashPassword(null,"Abcd@1234")
             }
            );




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

