using Application.Contracts.Infrastructure;
using Domain.Shop;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext : DbContext
{
    private readonly IDateTime _dateTime;
    private readonly IHttpContextAccessor _httpContext;
    public AppDbContext(DbContextOptions<AppDbContext> options, IDateTime dateTime, IHttpContextAccessor httpContext)
        : base(options)
    {
        _dateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
        _httpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
    }
    
    private string CurrentUsername
    {
        get
        {
            if (_httpContext.HttpContext == null) return "";
            var name = _httpContext.HttpContext
                .User
                .Claims
                .FirstOrDefault(x => x.Type.Equals("username", StringComparison.InvariantCultureIgnoreCase));

            return name == null ? "" : name.Value;
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

   public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var modifiedEntries = ChangeTracker.Entries()
            .Where(p => p.State == EntityState.Modified || p.State == EntityState.Added ||
                        p.State == EntityState.Deleted);
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
                item.Property("CreatedDate").CurrentValue = _dateTime.IranNow;
                item.Property("CreatedBy").CurrentValue = CurrentUsername;
                item.Property("IsActive").CurrentValue = true;
                item.Property("IsUpdated").CurrentValue = false;
                item.Property("IsDeleted").CurrentValue = false;
            }

            if (item.State == EntityState.Modified && updateDate != null && updateBy != null)
            {
                item.Property("UpdatedDate").CurrentValue = _dateTime.IranNow;
                item.Property("UpdatedBy").CurrentValue = CurrentUsername;
                item.Property("IsUpdated").CurrentValue = true;
            }

            if (item.State != EntityState.Deleted || deleteDate == null || deleteBy == null ||
                isDeleted == null) continue;
            item.Property("DeletedDate").CurrentValue = _dateTime.IranNow;
            item.Property("DeletedBy").CurrentValue = CurrentUsername;
            item.Property("IsDeleted").CurrentValue = true;
            item.Property("IsActive").CurrentValue = false;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}