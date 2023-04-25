using Domain.Shop;
using Microsoft.EntityFrameworkCore;
using Application.Contracts.Infrastructure;

namespace Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options, IDateTime dateTime)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public Task<int> SaveChangesAsync(string userName, DateTime now, CancellationToken cancellationToken = default)
    {
        var modifiedEntries = ChangeTracker.Entries()
            .Where(p => p.State is EntityState.Modified or EntityState.Added or EntityState.Deleted);
        foreach (var item in modifiedEntries)
        {
            var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());
            if (entityType == null) continue;
            var createDate = entityType.FindProperty("CreatedDate");
            var updateDate = entityType.FindProperty("UpdatedDate");
            var deleteDate = entityType.FindProperty("DeletedDate");
            var createBy = entityType.FindProperty("CreatedBy");
            var updateBy = entityType.FindProperty("UpdatedBy");
            var deleteBy = entityType.FindProperty("DeletedBy");
            var isDeleted = entityType.FindProperty("IsDeleted");


            if (item.State == EntityState.Added && createDate != null && createBy != null)
            {
                item.Property("CreatedDate").CurrentValue = now;
                item.Property("CreatedBy").CurrentValue = userName;
                item.Property("IsActive").CurrentValue = true;
                item.Property("IsUpdated").CurrentValue = false;
                item.Property("IsDeleted").CurrentValue = false;
            }

            if (item.State == EntityState.Modified && updateDate != null && updateBy != null)
            {
                item.Property("UpdatedDate").CurrentValue = now;
                item.Property("UpdatedBy").CurrentValue = userName;
                item.Property("IsUpdated").CurrentValue = true;
            }

            if (item.State != EntityState.Deleted || deleteDate == null || deleteBy == null ||
                isDeleted == null) continue;
            item.Property("DeletedDate").CurrentValue = now;
            item.Property("DeletedBy").CurrentValue = userName;
            item.Property("IsDeleted").CurrentValue = true;
            item.Property("IsActive").CurrentValue = false;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}