using FinControl.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinControl.Data.Mappings;

public class RecurrenceMapping : IEntityTypeConfiguration<Recurrence>
{
    public void Configure(EntityTypeBuilder<Recurrence> builder)
    {
        builder.ToTable("recurrences");
        builder.HasKey(x => x.Id);

        
        builder.Property(x => x.Quantity)
            .HasColumnName("quantity");
        builder.Property(x => x.Frequency)
            .HasColumnName("frequency");
        builder.Property(x => x.Id)
            .HasColumnName("id");
        builder.Property(x => x.AddedOn)
            .HasColumnName("addedon");
        builder.Property(x => x.AddedBy)
            .HasColumnName("addedby");
        
        builder.HasMany(x => x.Transactions)
            .WithOne(x => x.Recurrence)
            .HasForeignKey(x => x.RecurrenceId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}