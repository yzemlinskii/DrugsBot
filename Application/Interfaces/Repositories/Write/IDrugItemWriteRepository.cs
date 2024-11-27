using Domain.Entities;

namespace Application.Interfaces.Repositories.Write;

/// <summary>
/// Репозиторий для записи данных о препаратах в аптеках.
/// </summary>
public interface IDrugItemWriteRepository : IWriteRepository<DrugItem>
{
}