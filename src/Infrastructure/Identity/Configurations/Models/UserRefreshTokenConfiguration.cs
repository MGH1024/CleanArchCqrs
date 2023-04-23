﻿using Domain;
using Domain.Identity;
using Identity.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configurations.Models;
public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
{
    public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
    {
        builder.ToTable(DatabaseTableName.UserRefreshToken, DatabaseSchema.SecuritySchema);

        builder.Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Token)
            .HasMaxLength(2048)
            .IsRequired();

        builder.Property(t => t.RefreshToken)
          .HasMaxLength(2048)
          .IsRequired();

        builder.Property(t => t.CreatedDate)
        .IsRequired();

        builder.Property(t => t.ExpirationDate)
        .IsRequired();

        builder.Property(t => t.IpAddress)
        .HasMaxLength(20);


        //navigations
        builder.HasOne<User>(a => a.User)
       .WithMany(a => a.UserRefreshTokens)
       .HasForeignKey(a => a.UserId)
       .OnDelete(DeleteBehavior.Restrict);
    }
}
