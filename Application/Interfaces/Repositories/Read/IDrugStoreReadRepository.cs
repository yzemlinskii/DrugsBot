using Domain.Entities;

namespace Application.Interfaces.Repositories.Read;

/// <summary>
/// Репозиторий для чтения данных об аптеках.
/// </summary>
public interface IDrugStoreReadRepository : IReadRepository<DrugStore>
{
}