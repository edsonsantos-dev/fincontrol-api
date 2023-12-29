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
        
        builder.HasMany(x => x.Transactions)
            .WithOne(x => x.Recurrence)
            .HasForeignKey(x => x.RecurrenceId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}