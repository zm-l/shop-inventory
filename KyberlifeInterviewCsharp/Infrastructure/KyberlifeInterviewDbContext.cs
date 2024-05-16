using KyberlifeInterviewCsharp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KyberlifeInterviewCsharp.Infrastructure;

/// <summary>
/// DbContext for the application.
///
/// You should not need to modify this class.
/// </summary>
public class KyberlifeInterviewDbContext(DbContextOptions<KyberlifeInterviewDbContext> options)
    : DbContext(options)
{
    public DbSet<ShopItem> ShopItems { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShopItem>(ConfirmShopItem);
    }

    private static void ConfirmShopItem(EntityTypeBuilder<ShopItem> builder)
    {
        builder.Property(t => t.Id);
        builder.Property(t => t.Name)
            .IsRequired();
        builder.Property(t => t.Price)
            .HasAnnotation("Range", new[] { 0.01m, 1_000_000m }) //$0.01 to $1,000,000, values are arbitrary
            .IsRequired();
        builder.Property(t => t.IsSold)
            .IsRequired();
    }
}