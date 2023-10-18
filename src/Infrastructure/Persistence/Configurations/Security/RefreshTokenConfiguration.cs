using MGH.Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.Base;

namespace Persistence.Configurations.Security;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable(DatabaseTableName.RefreshToken, DatabaseSchema.SecuritySchema).HasKey(rt => rt.Id);
        
        builder.Property(rt => rt.Id).HasColumnName("Id").IsRequired();
        builder.Property(rt => rt.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(rt => rt.Token).HasColumnName("Token").IsRequired();
        builder.Property(rt => rt.Expires).HasColumnName("Expires").IsRequired();
        builder.Property(rt => rt.CreatedByIp).HasColumnName("CreatedByIp").IsRequired();
        builder.Property(rt => rt.Revoked).HasColumnName("Revoked");
        builder.Property(rt => rt.RevokedByIp).HasColumnName("RevokedByIp");
        builder.Property(rt => rt.ReplacedByToken).HasColumnName("ReplacedByToken");
        builder.Property(rt => rt.ReasonRevoked).HasColumnName("ReasonRevoked");
        builder.Property(uoc => uoc.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(uoc => uoc.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(uoc => uoc.DeletedAt).HasColumnName("DeletedAt");
        builder.Property(uoc => uoc.CreatedBy).HasColumnName("CreatedBy").IsRequired();
        builder.Property(uoc => uoc.UpdatedBy).HasColumnName("UpdatedBy");
        builder.Property(uoc => uoc.DeletedBy).HasColumnName("DeletedBy");

        builder.HasQueryFilter(rt => !rt.DeletedAt.HasValue);

        builder.HasOne(rt => rt.User);
    }
}
