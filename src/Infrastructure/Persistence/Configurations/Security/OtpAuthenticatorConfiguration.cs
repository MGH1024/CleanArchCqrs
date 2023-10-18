using MGH.Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.Base;

namespace Persistence.Configurations.Security;

public class OtpAuthenticatorConfiguration : IEntityTypeConfiguration<OtpAuthenticator>
{
    public void Configure(EntityTypeBuilder<OtpAuthenticator> builder)
    {
        builder.ToTable(DatabaseTableName.OtpAuthenticator, DatabaseSchema.SecuritySchema).HasKey(oa => oa.Id);

        builder.Property(oa => oa.Id).HasColumnName("Id").IsRequired();
        builder.Property(oa => oa.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(oa => oa.SecretKey).HasColumnName("SecretKey").IsRequired();
        builder.Property(oa => oa.IsVerified).HasColumnName("IsVerified").IsRequired();
        builder.Property(uoc => uoc.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(uoc => uoc.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(uoc => uoc.DeletedAt).HasColumnName("DeletedAt");
        builder.Property(uoc => uoc.CreatedBy).HasColumnName("CreatedBy").IsRequired();
        builder.Property(uoc => uoc.UpdatedBy).HasColumnName("UpdatedBy");
        builder.Property(uoc => uoc.DeletedBy).HasColumnName("DeletedBy");

        builder.HasQueryFilter(oa => !oa.DeletedAt.HasValue);

        builder.HasOne(oa => oa.User);
    }
}
