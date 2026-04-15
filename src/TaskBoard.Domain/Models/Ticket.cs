using TaskBoard.Domain.Enums;

namespace TaskBoard.Domain.Models;

public class Ticket
{
    public Guid Id { get; set; }
    public required string Title {  get; set; }
    public string? Description { get; set; }
    public Priority Priority { get; set; }
    public Status Status { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
    // Foreign Keys
    public Guid ProjectId { get; set; }
    public Guid? AssignedToUserId {  get; set; }

    // Navigation properties
    public Project Project { get; set; } = null!;
    public User? AssignedUser { get; set; }
}
