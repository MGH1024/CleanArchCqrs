using Domain.Entities.Security;
using Domain.Entities.Shop;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //table setting section
        builder.ToTable(DatabaseTableName.User, DatabaseSchema.SecuritySchema);
        
        
        //fix fields section
        builder.Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
    }
}
