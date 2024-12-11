using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Insfrastructure.Dal.Repositories.Write;

public abstract class BaseWriteRepository<T> : IWriteRepository<T> where T : class
{
    private readonly DbContext _dbContext;

    protected BaseWriteRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
    }

    public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken);

        if (entity == null)
        {
            throw new KeyNotFoundException("Сущность с ключом ID не найдена");
        }

        _dbContext.Set<T>().Remove(entity);
    }
}