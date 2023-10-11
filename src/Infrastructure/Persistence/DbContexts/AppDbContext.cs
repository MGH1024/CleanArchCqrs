using Application.Contracts.Infrastructure;
using Domain.Entities.Security;
using Domain.Entities.Shop;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using Persistence.Interceptors;

namespace Persistence.DbContexts;

public class AppDbContext : DbContext
{
    private readonly IDateTime _dateTime;
    public AppDbContext(DbContextOptions<AppDbContext> options, IDateTime dateTime)
        : base(options)
    {
        _dateTime = dateTime;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(128);
        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new AddAuditFieldsInterceptor(_dateTime));
        //base.OnConfiguring(optionsBuilder);
    }

    // public Task<int> SaveChangesAsync(string userName, DateTime now, CancellationToken cancellationToken = default)
    // {
    //     var modifiedEntries = ChangeTracker.Entries()
    //         .Where(p => p.State is EntityState.Modified or EntityState.Added or EntityState.Deleted);
    //     foreach (var item in modifiedEntries)
    //     {
    //         var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());
    //         if (entityType == null) continue;
    //         var createDate = entityType.FindProperty("CreatedDate");
    //         var updateDate = entityType.FindProperty("UpdatedDate");
    //         var deleteDate = entityType.FindProperty("DeletedDate");
    //         var createBy = entityType.FindProperty("CreatedBy");
    //         var updateBy = entityType.FindProperty("UpdatedBy");
    //         var deleteBy = entityType.FindProperty("DeletedBy");
    //         var isDeleted = entityType.FindProperty("IsDeleted");
    //
    //
    //         if (item.State == EntityState.Added && createDate != null && createBy != null)
    //         {
    //             item.Property("CreatedDate").CurrentValue = now;
    //             item.Property("CreatedBy").CurrentValue = userName;
    //             item.Property("IsActive").CurrentValue = true;
    //             item.Property("IsUpdated").CurrentValue = false;
    //             item.Property("IsDeleted").CurrentValue = false;
    //         }
    //
    //         if (item.State == EntityState.Modified && updateDate != null && updateBy != null)
    //         {
    //             item.Property("UpdatedDate").CurrentValue = now;
    //             item.Property("UpdatedBy").CurrentValue = userName;
    //             item.Property("IsUpdated").CurrentValue = true;
    //         }
    //
    //         if (item.State != EntityState.Deleted || deleteDate == null || deleteBy == null ||
    //             isDeleted == null) continue;
    //         item.Property("DeletedDate").CurrentValue = now;
    //         item.Property("DeletedBy").CurrentValue = userName;
    //         item.Property("IsDeleted").CurrentValue = true;
    //         item.Property("IsActive").CurrentValue = false;
    //     }
    //
    //     return base.SaveChangesAsync(cancellationToken);
    // }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    
    
    public DbSet<User> User { get; set; }
    public DbSet<OperationClaim> OperationClaim { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
}