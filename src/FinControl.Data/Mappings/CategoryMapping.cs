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
            .HasColumnName("name")
            .HasMaxLength(20);
        builder.Property(x => x.IsActive)
            .HasColumnName("isactive")
            .HasDefaultValue(true);
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
        builder.Property(x => x.AccountId)
            .HasColumnName("accountid");
        
        builder.HasIndex(x => x.AddedBy);
        builder.HasIndex(x => x.AddedOn);
        builder.HasIndex(x => x.RemovedOn);
        builder.HasIndex(x => x.IsActive);
        
        builder.HasOne(x => x.Account)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.AccountId);
    }
}