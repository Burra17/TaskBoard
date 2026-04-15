using TaskBoard.Domain.Enums;

namespace TaskBoard.Domain.Models;

public class User
{
    public Guid Id { get; set; }
    public required string UserName { get; set; }
    public string PasswordHash { get; set; } = null!;
    public Role Role { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation property
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
