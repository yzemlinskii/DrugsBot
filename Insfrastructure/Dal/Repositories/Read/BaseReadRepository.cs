using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace Insfrastructure.Dal.Repositories.Read;

public abstract class BaseReadRepository<T> : IReadRepository<T> where T : class
{
    private readonly DbContext _dbContext;

    protected BaseReadRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id, cancellationToken);
    }

    public Task<IQueryable<T>> GetQueryableAsync(ODataQueryOptions<T> queryOptions, CancellationToken cancellationToken = default)
    {
        var query = _dbContext.Set<T>().AsNoTracking();
        var filteredQuery = queryOptions.ApplyTo(query, new ODataQuerySettings()) as IQueryable<T>;
        return Task.FromResult(filteredQuery!);
    }
}