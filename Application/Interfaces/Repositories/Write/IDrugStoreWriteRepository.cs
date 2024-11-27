using Domain.Entities;

namespace Application.Interfaces.Repositories.Write;

/// <summary>
/// Репозиторий для записи данных об аптеках.
/// </summary>
public interface IDrugStoreWriteRepository : IWriteRepository<DrugStore>
{
}