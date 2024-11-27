using Domain.Entities;

namespace Application.Interfaces.Repositories.Write;

/// <summary>
/// Репозиторий для записи данных о профилях.
/// </summary>
public interface IProfileWriteRepository : IWriteRepository<Profile>
{
}