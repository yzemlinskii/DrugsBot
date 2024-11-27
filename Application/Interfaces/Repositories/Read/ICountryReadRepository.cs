using Domain.Entities;

namespace Application.Interfaces.Repositories.Read;

/// <summary>
/// Репозиторий для чтения данных о странах.
/// </summary>
public interface ICountryReadRepository : IReadRepository<Country>
{
}