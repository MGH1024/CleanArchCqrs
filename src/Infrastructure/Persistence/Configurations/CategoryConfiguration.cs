using Domain.Entities.Shop;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.Base;

namespace Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        //table
        builder.ToTable(DatabaseTableName.Category, DatabaseSchema.GeneralSchema);
        
        
        //fix fields section
        builder.Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();


        builder.Property(t => t.Title)
            .HasMaxLength(maxLength: 128)
            .IsRequired();

        builder.Property(t => t.Description)
           .HasMaxLength(maxLength: 256);



        //public
        builder.Ignore(a => a.Row);
        builder.Ignore(a => a.PageSize);
        builder.Ignore(a => a.TotalCount);
        builder.Ignore(a => a.CurrentPage);
        
        builder.Ignore(a => a.ListItemText);
        builder.Ignore(a => a.ListItemTextForAdmins);
        
        builder.Property(t => t.CreatedBy)
            .IsRequired()
            .HasMaxLength(maxLength: 64);
        
        builder.Property(t => t.CreatedAt)
            .IsRequired();
        
        builder.Property(t => t.UpdatedBy)
            .HasMaxLength(maxLength: 64);
        
        builder.Property(t => t.UpdatedAt)
            .IsRequired(false);
        
        builder.Property(t => t.DeletedBy)
            .HasMaxLength(maxLength: 64);
        
        builder.Property(t => t.DeletedAt)
            .IsRequired(false);

        builder.Property(a => a.CreatedBy)
            .HasDefaultValue("user");
        
        builder.Property(a => a.CreatedAt)
            .HasDefaultValueSql("GetDate()");
    }
}
