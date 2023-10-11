using Application.Contracts.Infrastructure;
using MGH.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Persistence.Interceptors;

public class AddAuditFieldsInterceptor :SaveChangesInterceptor
{
    private readonly IDateTime _dateTime;
    public AddAuditFieldsInterceptor(IDateTime dateTime)
    {
        _dateTime = dateTime;
    }

    public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var now = _dateTime.IranNow;
        var userName = "admin";
        if (eventData.Context != null)
        {
            var modifiedEntries = eventData.Context.ChangeTracker.Entries();
            var entityEntries = modifiedEntries.ToList();
            foreach (var item in entityEntries)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());
                if (entityType == null) continue;
                var createAt = entityType.FindProperty("CreatedAt");
                var updateAt = entityType.FindProperty("UpdatedAt");
                var deleteAt = entityType.FindProperty("DeletedAt");
                var createBy = entityType.FindProperty("CreatedBy");
                var updateBy = entityType.FindProperty("UpdatedBy");
                var deleteBy = entityType.FindProperty("DeletedBy");


                if (item.State == EntityState.Added && createAt != null && createBy != null)
                {
                    item.Property("CreatedDate").CurrentValue = now;
                    item.Property("CreatedBy").CurrentValue = userName;
                    item.Property("IsActive").CurrentValue = true;
                    item.Property("IsUpdated").CurrentValue = false;
                    item.Property("IsDeleted").CurrentValue = false;
                }
    
                if (item.State == EntityState.Modified && updateAt != null && updateBy != null)
                {
                    item.Property("UpdatedDate").CurrentValue = now;
                    item.Property("UpdatedBy").CurrentValue = userName;
                    item.Property("IsUpdated").CurrentValue = true;
                }
    
                if (item.State != EntityState.Deleted || deleteAt == null || deleteBy == null ) continue;
                item.Property("DeletedDate").CurrentValue = now;
                item.Property("DeletedBy").CurrentValue = userName;
                item.Property("IsDeleted").CurrentValue = true;
                item.Property("IsActive").CurrentValue = false;
            }
        }
        return base.SavedChangesAsync(eventData, result, cancellationToken);
    }
}