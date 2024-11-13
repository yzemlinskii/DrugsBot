using FluentValidation;
using Domain.ValueObjects;
using Domain.Primitives;

namespace Domain.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        private static readonly HashSet<string> ValidIsoCodes = ["US", "DE", "FR", "GB", "CA", "IT", "ES", "RU"];

        public AddressValidator()
        {
            // Валидация для City
            RuleFor(a => a.City)
                .NotEmpty().WithMessage(ValidationMessage.RequiredField)
                .Length(2, 50).WithMessage(ValidationMessage.LengthField)
                .Matches(@"^[A-Za-z\s\-]+$").WithMessage(ValidationMessage.OnlyLettersSpacesAndDashes);

            // Валидация для Street
            RuleFor(a => a.Street)
                .NotEmpty().WithMessage(ValidationMessage.RequiredField)
                .Length(3, 100).WithMessage(ValidationMessage.LengthField)
                .Matches(@"^[A-Za-z0-9\s\-]+$").WithMessage(ValidationMessage.OnlyLettersDigitsSpacesAndDashes);

            // Валидация для House
            RuleFor(a => a.House)
                .NotEmpty().WithMessage(ValidationMessage.RequiredField)
                .Length(1, 10).WithMessage(ValidationMessage.LengthField)
                .Matches(@"^[A-Za-z0-9\-]+$").WithMessage(ValidationMessage.OnlyLettersDigitsAndDashes);

            // Валидация для CountryCode
            RuleFor(a => a.CountryCode)
                .NotEmpty().WithMessage(ValidationMessage.RequiredField)
                .Length(2).WithMessage(ValidationMessage.ExactLengthField)
                .Matches(@"^[A-Z]{2}$").WithMessage(ValidationMessage.OnlyUppercaseLetters)
                .Must(code => ValidIsoCodes.Contains(code)).WithMessage(ValidationMessage.ValidCountryCode);
        }
    }
}