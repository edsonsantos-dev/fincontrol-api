using FinControl.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinControl.Data.Mappings;

public class TransactionMapping : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("transactions");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Amount)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("amount")
            .IsRequired();
        builder.Property(x => x.Description)
            .HasMaxLength(100)
            .HasColumnName("description")
            .IsRequired();
        builder.Property(x => x.Id)
            .HasColumnName("id");
        builder.Property(x => x.AddedOn)
            .HasColumnName("addedon");
        builder.Property(x => x.AddedBy)
            .HasColumnName("addedby");
        builder.Property(x => x.ModifiedOn)
            .HasColumnName("modifiedon");
        builder.Property(x => x.ModifiedBy)
            .HasColumnName("modifiedby");
        builder.Property(x => x.RemovedOn)
            .HasColumnName("removedn");
        builder.Property(x => x.RemovedBy)
            .HasColumnName("removedby");
        builder.Property(x => x.CategoryId)
            .HasColumnName("categoryid");
        builder.Property(x => x.AccountId)
            .HasColumnName("accountid");
        
        builder.HasIndex(x => x.AddedBy);
        builder.HasIndex(x => x.AddedOn);
        builder.HasIndex(x => x.RemovedOn);
        
        builder.HasOne(x => x.Category)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.CategoryId);
        builder.HasOne(x => x.Account)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.AccountId);
    }
}