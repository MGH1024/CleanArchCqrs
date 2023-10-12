using Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.Base;

namespace Persistence.Configurations.Security;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        //table
        builder.ToTable(DatabaseTableName.Permission, DatabaseSchema.SecuritySchema);
        
        //fields
        builder.Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(128);
        
        //constraint
        builder.HasIndex(a => a.Title)
            .IsUnique();
            
        //navigations
        builder.HasOne(a => a.Role)
            .WithMany(a => a.Permissions)
            .HasForeignKey(a => a.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}