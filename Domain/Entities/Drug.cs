using Domain.Validators;

namespace Domain.Entities;

/// <summary>
/// Лекарственный препарат
/// </summary>
public class Drug : BaseEntity<Drug>
{
    public Drug(string name, string manufacturer, string countryCodeId, Country country, Func<string, bool> countryExistsFunc)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeId = countryCodeId;
        Country = country;

        // Вызов валидации через базовый класс с использованием переданной функции проверки
        ValidateEntity(new DrugValidator(countryExistsFunc));
    }

    /// <summary>
    /// Название препарата.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Производитель препарата.
    /// </summary>
    public string Manufacturer { get; private set; }

    /// <summary>
    /// Код страны производителя.
    /// </summary>
    public string CountryCodeId { get; private set; }

    /// <summary>
    /// Связь с объектом Country.
    /// </summary>
    public Country Country { get; private set; }

    /// <summary>
    /// Навигационное свойство для связи с DrugItem.
    /// </summary>
    public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
}