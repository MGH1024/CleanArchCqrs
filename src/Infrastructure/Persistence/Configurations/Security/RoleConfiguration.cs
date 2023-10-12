using Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.Base;

namespace Persistence.Configurations.Security;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        //table
        builder.ToTable(DatabaseTableName.Role, DatabaseSchema.SecuritySchema);


        //fields
        builder.Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(128);


        //constraint
        builder.HasIndex(a => a.Title)
            .IsUnique();


        //seed
        builder.HasData
        (
            new Role()
            {
                Id = 1,
                Title = "ProductManagement"
            },
            new Role()
            {
                Id = 2,
                Title = "CategoryManagement"
            }
        );
    }
}