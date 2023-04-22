using Domain.Shop;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        //table setting section
        builder.ToTable(DatabaseTableName.Category, DatabaseSchema.GeneralSchema);
        
        
        //fix fields section
        builder.Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();


        builder.Property(t => t.Title)
            .HasMaxLength(maxLength: 512)
            .IsRequired();

        builder.Property(t => t.Description)
           .HasMaxLength(maxLength: 256);



        //not mapped section
        builder.Ignore(a => a.Row);
        builder.Ignore(a => a.PageSize);
        builder.Ignore(a => a.TotalCount);
        builder.Ignore(a => a.CurrentPage);
        builder.Ignore(a => a.ListItemText);
        builder.Ignore(a => a.ListItemTextForAdmins);

        //default value  section
        builder.Property(t => t.IsActive).HasDefaultValue(true);
        builder.Property(t => t.IsDeleted).HasDefaultValue(false);
        builder.Property(t => t.IsUpdated).HasDefaultValue(false);
        
        
        //navigations
    }
}
