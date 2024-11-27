using Domain.Entities;

namespace Application.Interfaces.Repositories.Read;

/// <summary>
/// Репозиторий для чтения данных об избранных препаратах.
/// </summary>
public interface IFavoriteDrugReadRepository : IReadRepository<FavoriteDrug>
{
}