using FluentValidation;
using Domain.Entities;

namespace Domain.Validators;

public sealed class DrugItemValidator : AbstractValidator<DrugItem>
{
    public DrugItemValidator()
    {
        // Валидация для Cost (стоимость)
        RuleFor(d => d.Cost)
            .GreaterThan(0).WithMessage("Поле {PropertyName} должно быть положительным числом.")
            .ScalePrecision(2, 18).WithMessage("Поле {PropertyName} должно содержать не более двух знаков после запятой.");

        // Валидация для Count (количество)
        RuleFor(d => d.Count)
            .GreaterThanOrEqualTo(0).WithMessage("Поле {PropertyName} должно быть неотрицательным числом.")
            .LessThanOrEqualTo(10_000).WithMessage("Поле {PropertyName} не должно превышать 10 000.");
    }
}