using Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.Base;

namespace Persistence.Configurations.Security;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        //table
        builder.ToTable(DatabaseTableName.UserRole, DatabaseSchema.SecuritySchema);
        
        
        //fields
        builder.Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        
        //navigations
        builder.HasOne(a => a.User)
            .WithMany(a => a.UserRoles)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict);
      
        builder.HasOne(a => a.Role)
            .WithMany(a => a.UserRoles)
            .HasForeignKey(a => a.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
        
    }
}
