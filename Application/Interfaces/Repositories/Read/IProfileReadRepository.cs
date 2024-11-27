using Domain.Entities;

namespace Application.Interfaces.Repositories.Read;

/// <summary>
/// Репозиторий для чтения данных о профилях.
/// </summary>
public interface IProfileReadRepository : IReadRepository<Profile>
{
}