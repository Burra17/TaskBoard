namespace TaskBoard.Application.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
