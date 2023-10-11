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
    }
    

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    
    
    public DbSet<User> User { get; set; }
    public DbSet<OperationClaim> OperationClaim { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
}