using Domain.Interfaces;

namespace Domain.Events;

/// <summary>
/// Доменное событие обновления единицы лекарства.
/// </summary>
public sealed class DrugItemUpdatedEvent : IDomainEvent
{
    internal DrugItemUpdatedEvent(){}
}