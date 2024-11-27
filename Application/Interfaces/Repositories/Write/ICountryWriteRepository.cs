using Domain.Entities;

namespace Application.Interfaces.Repositories.Write;

/// <summary>
/// Репозиторий для записи данных о странах.
/// </summary>
public interface ICountryWriteRepository : IWriteRepository<Country>
{
}