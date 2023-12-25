using FinControl.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinControl.Data.Mappings;

public class AccountMapping : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("accounts");
        builder.HasKey(x => x.Id);

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
    }
}