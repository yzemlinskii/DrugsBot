using Domain.Entities;

namespace Application.Interfaces.Repositories.Write;

/// <summary>
/// Репозиторий для записи данных об избранных препаратах.
/// </summary>
public interface IFavoriteDrugWriteRepository : IWriteRepository<FavoriteDrug>
{
}