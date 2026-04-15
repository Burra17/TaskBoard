using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Models;

namespace TaskBoard.Infrastructure.Database;

public class AppDbContext : DbContext
{
    // Configuration
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Models
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<User> Users => Set<User>();

    // Explicit relationship configuration (EF Core would infer these, but kept for clarity)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasOne(t => t.Project)
                  .WithMany(p => p.Tickets)
                  .HasForeignKey(t => t.ProjectId);

            entity.HasOne(t => t.AssignedUser)
                  .WithMany(u => u.Tickets)
                  .HasForeignKey(t => t.AssignedToUserId)
                  .IsRequired(false);
        });
    }
}
