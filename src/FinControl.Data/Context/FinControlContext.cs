using FinControl.Business.Interfaces;
using FinControl.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace FinControl.Data.Context;

public sealed class FinControlContext : DbContext
{
    private readonly IUserContext _userContext;
    public Guid UserId => _userContext.GetUserId();
    public Guid AccountId => _userContext.GetAccountId();

    public FinControlContext(
        DbContextOptions<FinControlContext> options,
        IUserContext userContext) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
        _userContext = userContext;
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinControlContext).Assembly);

        foreach (var item in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            item.DeleteBehavior = DeleteBehavior.ClientSetNull;

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = new CancellationToken())
    {
        HandleAddedOnAndAddedByForEntities();
        HandleModifiedOnAndModifiedByForEntities();

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void HandleAddedOnAndAddedByForEntities()
    {
        var entityEntries = ChangeTracker
            .Entries()
            .Where(x => x.Entity.GetType().GetProperty("AddedOn") != null ||
                        x.Entity.GetType().GetProperty("AddedBy") != null ||
                        x.Entity.GetType().GetProperty("UserId") != null ||
                        x.Entity.GetType().GetProperty("AccountId") != null);

        foreach (var entityEntry in entityEntries)
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Property("AddedOn").CurrentValue = DateTime.UtcNow;
                entityEntry.Property("AddedBy").CurrentValue = UserId;
                entityEntry.Property("UserId").CurrentValue = UserId;
                entityEntry.Property("AccountId").CurrentValue = AccountId;
            }

            if (entityEntry.State != EntityState.Modified) continue;

            entityEntry.Property("AddedOn").IsModified = false;
            entityEntry.Property("AddedBy").IsModified = false;
            entityEntry.Property("UserId").IsModified = false;
            entityEntry.Property("AccountId").IsModified = false;
        }
    }

    private void HandleModifiedOnAndModifiedByForEntities()
    {
        var entityEntries = ChangeTracker
            .Entries()
            .Where(x => x.Entity.GetType().GetProperty("ModifiedOn") != null ||
                        x.Entity.GetType().GetProperty("ModifiedBy") != null);

        foreach (var entityEntry in entityEntries)
        {
            if (entityEntry.State == EntityState.Added) continue;

            entityEntry.Property("ModifiedOn").CurrentValue = DateTime.UtcNow;
            entityEntry.Property("ModifiedBy").CurrentValue = UserId;
        }
    }
}