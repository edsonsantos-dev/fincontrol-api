using FinControl.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinControl.Data.Mappings;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);
        
        builder.HasIndex(x => x.AddedBy);
        builder.HasIndex(x => x.AddedOn);
        builder.HasIndex(x => x.RemovedOn);
        builder.HasIndex(x => x.IsActive);
        
        builder.HasOne(x => x.Account)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.AccountId);
    }
}