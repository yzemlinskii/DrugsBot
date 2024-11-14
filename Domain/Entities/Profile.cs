using Domain.Validators;
using Domain.ValueObjects;

namespace Domain.Entities;

public sealed class Profile : BaseEntity<Profile>
{
    public Profile(string externalId, Email? email)
    {
        ExternalId = externalId;
        Email = email;

        ValidateEntity(new ProfileValidator());
    }

    /// <summary>
    /// Внешний идентификатор.
    /// </summary>
    public string ExternalId { get; private init; }

    /// <summary>
    /// Электронная почта.
    /// </summary>
    public Email? Email { get; private set; }

    // Навигационное свойство для связи с FavoriteDrug.
    public List<FavoriteDrug> FavoriteDrugs { get; private set; } = [];
}