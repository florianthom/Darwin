using hello_asp_identity.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hello_asp_identity.Data.EntityConfigurations;

public class RefreshTokenEntityTypeConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable(nameof(RefreshToken).ToLower(), DbContext.DEFAULT_SCHEMA);

        builder.HasKey(a => a.Token);
        builder.Property(a => a.Token)
            .ValueGeneratedOnAdd();

        builder.HasOne(a => a.User)
            .WithMany()
            .HasForeignKey(a => nameof(a.UserId))
            .IsRequired(true)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}