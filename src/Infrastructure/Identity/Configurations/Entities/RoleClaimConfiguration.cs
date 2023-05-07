﻿using Domain.Entities.Identity;
using Identity.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configurations.Entities;

public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.ToTable(DatabaseTableName.RoleClaim, DatabaseSchema.SecuritySchema);

        builder.HasData(new RoleClaim
        {
            Id=1,
            RoleId=1,
            ClaimType = "roleName",
            ClaimValue= "Administrator"
        }, 
        new RoleClaim
        {
            Id = 2,
            RoleId = 2,
            ClaimType = "roleName",
            ClaimValue = "User"
        });

        builder.Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(t => t.ClaimType)
            .HasMaxLength(512);

        builder.Property(t => t.ClaimValue)
             .HasMaxLength(256);

    }
}

