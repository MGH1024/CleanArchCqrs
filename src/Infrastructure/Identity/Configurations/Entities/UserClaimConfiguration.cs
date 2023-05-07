using Domain.Entities.Identity;
using Identity.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configurations.Entities;

public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable(DatabaseTableName.UserClaim, DatabaseSchema.SecuritySchema);


        //seed data
        builder.HasData
        (
            new UserClaim
            {
                Id = 1,
                UserId = 1,
                ClaimType = "userName",
                ClaimValue = "admin"
            },
            new UserClaim
            {
                Id = 2,
                UserId = 1,
                ClaimType = "email",
                ClaimValue = "admin@admin.com"
            },
            new UserClaim
            {
                Id = 3,
                UserId = 1,
                ClaimType = "givenName",
                ClaimValue = "admin"
            },
            new UserClaim
            {
                Id = 4,
                UserId = 1,
                ClaimType = "surName",
                ClaimValue = "admin"
            }
        );


        builder.Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(t => t.ClaimType)
            .HasMaxLength(512);

        builder.Property(t => t.ClaimValue)
            .HasMaxLength(256);
    }
}