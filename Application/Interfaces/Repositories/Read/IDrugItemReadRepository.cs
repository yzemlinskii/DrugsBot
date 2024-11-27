using Domain.Entities;

namespace Application.Interfaces.Repositories.Read;

/// <summary>
/// Репозиторий для чтения данных о препаратах в аптеках.
/// </summary>
public interface IDrugItemReadRepository : IReadRepository<DrugItem>
{
}