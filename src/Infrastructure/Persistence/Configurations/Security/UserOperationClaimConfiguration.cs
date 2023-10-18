using MGH.Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.Base;

namespace Persistence.Configurations.Security;

public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable(DatabaseTableName.UserOperationClaim, DatabaseSchema.SecuritySchema).HasKey(uoc => uoc.Id);

        builder.Property(uoc => uoc.Id).HasColumnName("Id").IsRequired();
        builder.Property(uoc => uoc.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(uoc => uoc.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();
        builder.Property(uoc => uoc.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(uoc => uoc.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(uoc => uoc.DeletedAt).HasColumnName("DeletedAt");
        builder.Property(uoc => uoc.CreatedBy).HasColumnName("CreatedBy").IsRequired();
        builder.Property(uoc => uoc.UpdatedBy).HasColumnName("UpdatedBy");
        builder.Property(uoc => uoc.DeletedBy).HasColumnName("DeletedBy");

        builder.HasQueryFilter(uoc => !uoc.DeletedAt.HasValue);

        builder.HasOne(uoc => uoc.User);
        builder.HasOne(uoc => uoc.OperationClaim);

        builder.HasData(GetSeeds());
    }

    private IEnumerable<UserOperationClaim> GetSeeds()
    {
        List<UserOperationClaim> userOperationClaims = new();

        UserOperationClaim adminUserOperationClaim = new(id: 1, userId: 1, operationClaimId: 1);
        userOperationClaims.Add(adminUserOperationClaim);

        return userOperationClaims;
    }
}