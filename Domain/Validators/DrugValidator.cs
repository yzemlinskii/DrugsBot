using FluentValidation;
using Domain.Entities;
using Domain.Primitives;

namespace Domain.Validators;

public sealed class DrugValidator : AbstractValidator<Drug>
{
    public DrugValidator(Func<string, bool> countryExistsFunc)
    {
        // Валидация для Namea
        RuleFor(d => d.Name)
            .NotEmpty().WithMessage(ValidationMessage.RequiredField)
            .Length(2, 150).WithMessage(ValidationMessage.LengthField)
            .Matches(@"^[A-Za-z0-9\s]+$").WithMessage(ValidationMessage.OnlyLettersDigitsAndSpaces);

        // Валидация для Manufacturer
        RuleFor(d => d.Manufacturer)
            .NotEmpty().WithMessage(ValidationMessage.RequiredField)
            .Length(2, 100).WithMessage(ValidationMessage.LengthField)
            .Matches(@"^[A-Za-z\s\-]+$").WithMessage(ValidationMessage.OnlyLettersSpacesAndDashes);

        // Валидация для CountryCodeId
        RuleFor(d => d.CountryCodeId)
            .NotEmpty().WithMessage(ValidationMessage.RequiredField)
            .Length(2).WithMessage(ValidationMessage.ExactLengthField)
            .Matches("^[A-Z]{2}$").WithMessage(ValidationMessage.OnlyUppercaseLetters)
            .Must(countryExistsFunc).WithMessage(ValidationMessage.ValidCountryCode);
    }
}