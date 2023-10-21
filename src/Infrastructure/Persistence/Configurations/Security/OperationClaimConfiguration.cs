using MGH.Core.Security.Constants;
using MGH.Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.Base;

namespace Persistence.Configurations.Security;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable(DatabaseTableName.OperationClaim, DatabaseSchema.SecuritySchema).HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(uoc => uoc.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(uoc => uoc.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(uoc => uoc.DeletedAt).HasColumnName("DeletedAt");
        builder.Property(uoc => uoc.CreatedBy).HasColumnName("CreatedBy").IsRequired();
        builder.Property(uoc => uoc.UpdatedBy).HasColumnName("UpdatedBy");
        builder.Property(uoc => uoc.DeletedBy).HasColumnName("DeletedBy");

        builder.HasQueryFilter(oc => !oc.DeletedAt.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(GetSeeds());
    }

    private HashSet<OperationClaim> GetSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim
                    { Id = ++id, Name = GeneralOperationClaims.Admin, CreatedBy = "admin", CreatedAt = DateTime.Now }
            };

        return seeds;
    }
}