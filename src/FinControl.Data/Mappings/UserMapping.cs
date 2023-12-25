using FinControl.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinControl.Data.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasColumnName("firstname")
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(x => x.LastName)
            .HasColumnName("lastname")
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(x => x.Email)
            .HasColumnName("email")
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.PasswordHash)
            .HasColumnName("passwordhash")
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.IsActive)
            .HasColumnName("isactive")
            .HasDefaultValue(true);
        builder.Property(x => x.AccountId)
            .HasColumnName("accountid")
            .IsRequired();
        builder.Property(x => x.Role)
            .HasColumnName("role")
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

        builder.HasOne(x => x.Account)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.AccountId);
    }
}