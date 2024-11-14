using FluentValidation;
using Domain.Entities;
using Domain.Primitives;

namespace Domain.Validators;

public sealed class DrugStoreValidator : AbstractValidator<DrugStore>
{
    public DrugStoreValidator()
    {
            // Валидация для DrugNetwork
            RuleFor(d => d.DrugNetwork)
                .NotEmpty().WithMessage(ValidationMessage.RequiredField)
                .Length(2, 100).WithMessage(ValidationMessage.LengthField);

            // Валидация для Number
            RuleFor(d => d.Number)
                .GreaterThan(0).WithMessage(ValidationMessage.PositiveNumber);

            // Валидация для Address (только проверка на null)
            RuleFor(d => d.Address)
                .NotNull().WithMessage(ValidationMessage.RequiredField)
                .SetValidator(new AddressValidator());
        }
}