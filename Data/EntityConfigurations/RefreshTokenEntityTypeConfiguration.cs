using Darwin.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Darwin.Data.EntityConfigurations;

public class RefreshTokenEntityTypeConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable(nameof(RefreshToken), AppDbContext.DEFAULT_SCHEMA);

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Token)
            .ValueGeneratedOnAdd();

        builder.HasOne(a => a.User)
            .WithMany()
            .HasForeignKey(nameof(RefreshToken.UserId))
            .IsRequired(true)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}