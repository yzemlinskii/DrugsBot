namespace Application.Interfaces.Repositories;

public interface IWriteRepository<T> where T : class
{
    /// <summary>
    /// Репозиторий для операций чтения
    /// </summary>
    IReadRepository<T> ReadRepository { get; }
    
    /// <summary>
    /// Метод для добавления сущности
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}