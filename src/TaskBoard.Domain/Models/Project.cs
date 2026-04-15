namespace TaskBoard.Domain.Models;

public class Project
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation property
    public ICollection<Ticket> Tickets {  get; set; } = new List<Ticket>();
}
