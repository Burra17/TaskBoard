using Microsoft.EntityFrameworkCore;
using TaskBoard.Application.Interfaces;
using TaskBoard.Domain.Models;

namespace TaskBoard.Infrastructure.Database;

public class AppDbContext : DbContext, IUnitOfWork
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

    // Explicit IUnitOfWork implementation — wraps EF Core's SaveChangesAsync
    async Task IUnitOfWork.SaveChangesAsync()
    {
        await base.SaveChangesAsync();
    }

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
