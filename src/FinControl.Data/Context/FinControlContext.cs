﻿using FinControl.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace FinControl.Data.Context;

public sealed class FinControlContext : DbContext
{
    public FinControlContext(DbContextOptions<FinControlContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
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
                        x.Entity.GetType().GetProperty("AddedBy") != null);

        foreach (var entityEntry in entityEntries)
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Property("AddedOn").CurrentValue = DateTime.UtcNow;
                //TODO: added by will be set by login context 
            }

            if (entityEntry.State != EntityState.Modified) continue;

            entityEntry.Property("AddedOn").IsModified = false;
            entityEntry.Property("AddedBy").IsModified = false;
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
            //TODO: modified by will be set by login context 
        }
    }
}