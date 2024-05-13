using KyberlifeInterviewCsharp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KyberlifeInterviewCsharp.Infrastructure;

public class KyberlifeInterviewDbContext(DbContextOptions<KyberlifeInterviewDbContext> options, DbSet<Todo> todos)
    : DbContext(options)
{
    public DbSet<Todo> Todos { get; init; } = todos;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>(ConfigureTodo);
    }

    private static void ConfigureTodo(EntityTypeBuilder<Todo> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Title).IsRequired();
        builder.Property(t => t.Description).IsRequired();
        builder.Property(t => t.IsComplete).IsRequired();
    }
}