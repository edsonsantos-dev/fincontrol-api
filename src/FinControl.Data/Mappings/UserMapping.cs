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
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.PasswordHash)
            .HasMaxLength(100);
        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);
        builder.Property(x => x.AccountId)
            .IsRequired();
        builder.Property(x => x.Role)
            .IsRequired();

        builder.HasIndex(x => x.Email);

        builder.HasOne(x => x.Account)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.AccountId);
    }
}