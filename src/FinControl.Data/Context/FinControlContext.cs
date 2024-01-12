using FinControl.Business.Interfaces;
using FinControl.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
        HandleRemovedOnAndRemovedByForEntities();

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void HandleAddedOnAndAddedByForEntities()
    {
        var entityEntries = ChangeTracker.Entries()
            .Where(x => x.Entity.GetType().GetProperty("AddedOn") != null ||
                        x.Entity.GetType().GetProperty("AddedBy") != null ||
                        x.Entity.GetType().GetProperty("UserId") != null ||
                        x.Entity.GetType().GetProperty("AccountId") != null);

        foreach (var entityEntry in entityEntries)
        {
            var isAddedState = entityEntry.State == EntityState.Added;
            var isModifiedState = entityEntry.State == EntityState.Modified;

            SetPropertyIfNotNull(entityEntry, "AddedOn", DateTime.UtcNow, isAddedState, isModifiedState);
            SetPropertyIfNotNull(entityEntry, "AddedBy", UserId, isAddedState, isModifiedState);
            SetPropertyIfNotNull(entityEntry, "UserId", UserId, isAddedState, !isAddedState, Guid.Empty);
            SetPropertyIfNotNull(entityEntry, "AccountId", AccountId, isAddedState, !isAddedState, Guid.Empty);
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
            if (entityEntry.State != EntityState.Modified) continue;

            entityEntry.Property("ModifiedOn").CurrentValue = DateTime.UtcNow;
            entityEntry.Property("ModifiedBy").CurrentValue = UserId;
        }
    }

    private void HandleRemovedOnAndRemovedByForEntities()
    {
        var entityEntries = ChangeTracker
            .Entries()
            .Where(x => x.Entity.GetType().GetProperty("RemovedOn") != null ||
                        x.Entity.GetType().GetProperty("RemovedBy") != null);

        foreach (var entityEntry in entityEntries)
        {
            if (entityEntry.State != EntityState.Deleted) continue;

            entityEntry.Property("RemovedOn").CurrentValue = DateTime.UtcNow;
            entityEntry.Property("RemovedBy").CurrentValue = UserId;

            entityEntry.State = EntityState.Modified;
        }
    }
    
    private static void SetPropertyIfNotNull(
        EntityEntry entityEntry, 
        string propertyName, 
        object newValue, 
        bool changeValueIfAddedState, 
        bool changeIsModifiedIfModifiedState, 
        Guid? condition = null)
    {
        var property = entityEntry.Metadata.FindProperty(propertyName);

        if (property == null) return;
        
        if (changeValueIfAddedState && (condition == null || (Guid)entityEntry.Property(propertyName).CurrentValue! == condition.Value))
            entityEntry.Property(propertyName).CurrentValue = newValue;

        if (changeIsModifiedIfModifiedState)
            entityEntry.Property(propertyName).IsModified = false;
    }
}