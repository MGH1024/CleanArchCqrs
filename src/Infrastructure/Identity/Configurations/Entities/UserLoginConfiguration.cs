﻿using Domain.Entities.Identity;
using Identity.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configurations.Entities;

public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable(DatabaseTableName.UserLogin, DatabaseSchema.SecuritySchema);


        builder.Property(t => t.ProviderDisplayName)
            .HasMaxLength(512);
    }
}

