using Company.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Company.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _entities;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id) => await _entities.FindAsync(id);

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _entities.AddAsync(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        _entities.Remove(entity);
    }

    public void Update(T entity)
    {
        _entities.Update(entity);
    }
}
