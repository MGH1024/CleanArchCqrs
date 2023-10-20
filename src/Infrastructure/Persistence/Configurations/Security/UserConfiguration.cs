using MGH.Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MGH.Core.Security.Hashing;
using Persistence.Configurations.Base;

namespace Persistence.Configurations.Security;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(DatabaseTableName.User, DatabaseSchema.SecuritySchema).HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(u => u.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType").IsRequired();
        builder.Property(uoc => uoc.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(uoc => uoc.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(uoc => uoc.DeletedAt).HasColumnName("DeletedAt");
        builder.Property(uoc => uoc.CreatedBy).HasColumnName("CreatedBy").IsRequired();
        builder.Property(uoc => uoc.UpdatedBy).HasColumnName("UpdatedBy");
        builder.Property(uoc => uoc.DeletedBy).HasColumnName("DeletedBy");

        builder.HasQueryFilter(u => !u.DeletedAt.HasValue);

        builder.HasMany(u => u.UserOperationClaims);
        builder.HasMany(u => u.RefreshTokens);
        builder.HasMany(u => u.EmailAuthenticators);
        builder.HasMany(u => u.OtpAuthenticators);

        builder.HasData(GetSeeds());
    }

    private IEnumerable<User> GetSeeds()
    {
        List<User> users = new();

        HashingHelper.CreatePasswordHash(
            password: "Abcd@1234",
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
        );
        User adminUser =
            new()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "GH",
                Email = "admin@admin.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedBy = "admin",
                CreatedAt = DateTime.Now
            };
        users.Add(adminUser);

        return users.ToArray();
    }
}