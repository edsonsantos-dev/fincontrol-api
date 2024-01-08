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
            .IsRequired();
        builder.Property(x => x.Description)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.Installment)
            .HasDefaultValue(1);
        
        builder.HasIndex(x => x.AddedBy);
        builder.HasIndex(x => x.AddedOn);
        builder.HasIndex(x => x.RemovedOn);
        builder.HasIndex(x => x.DueDate);
        
        builder.HasOne(x => x.Category)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.CategoryId);
        builder.HasOne(x => x.Account)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.AccountId);
        builder.HasOne(x => x.User)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.UserId);
    }
}