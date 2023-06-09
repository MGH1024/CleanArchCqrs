﻿using Domain.Entities.Identity;
using Identity.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configurations.Entities;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable(DatabaseTableName.UseRole, DatabaseSchema.SecuritySchema);

        builder.HasData
            (new UserRole
            {
                RoleId=1,
                UserId=1,
            });
    }
}
