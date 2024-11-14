using Domain.Events;
using Domain.Validators;

namespace Domain.Entities;

/// <summary>
/// Связь между препаратом и аптекой
/// </summary>
public class DrugItem : BaseEntity<DrugItem>
{
    public DrugItem(Guid drugId, Guid drugStoreId, decimal cost, int count, Drug drug, DrugStore drugStore)
    {
        DrugId = drugId;
        DrugStoreId = drugStoreId;
        Cost = cost;
        Count = count;
        Drug = drug;
        DrugStore = drugStore;

        // Вызов валидации через базовый класс
        ValidateEntity(new DrugItemValidator());
    }

    #region Свойства

    /// <summary>
    /// Идентификатор препарата.
    /// </summary>
    public Guid DrugId { get; private set; }

    /// <summary>
    /// Идентификатор аптеки.
    /// </summary>
    public Guid DrugStoreId { get; private set; }

    /// <summary>
    /// Стоимость препарата в данной аптеке.
    /// </summary>
    public decimal Cost { get; private set; }

    /// <summary>
    /// Количество препарата на складе.
    /// </summary>
    public double Count { get; private set; }

    // Навигационные свойства
    public Drug Drug { get; private set; }
    public DrugStore DrugStore { get; private set; }

    #endregion

    #region Методы

    /// <summary>
    /// Обновить количество препарата на складе.
    /// </summary>
    /// <param name="count"></param>
    public void UpdateCount(double count)
    {
        Count = count;

        ValidateEntity(new DrugItemValidator());

        AddDomainEvent(new DrugItemUpdatedEvent());
    }

    #endregion
}