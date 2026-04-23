using Microsoft.EntityFrameworkCore;
using TaskBoard.Application.Common.Pagination;
using TaskBoard.Application.Interfaces;
using TaskBoard.Infrastructure.Database;

namespace TaskBoard.Infrastructure.Repositories;

// Generic repository implementation using EF Core
public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }


    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public async Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize)
    {
        var query = _dbSet.AsNoTracking();

        var totalCount = await query.CountAsync();

        var items = await query
            .OrderBy(x => EF.Property<Guid>(x, "Id"))
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalCount);
    }
}
