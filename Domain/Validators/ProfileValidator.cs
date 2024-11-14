using FluentValidation;
using Domain.Entities;
using Domain.Primitives;

namespace Domain.Validators;

public sealed class ProfileValidator : AbstractValidator<Profile>
{
    public ProfileValidator()
    {
        // Валидация для ExternalId (внешнего идентификатора)
        RuleFor(d => d.ExternalId)
            .NotEmpty().WithMessage(ValidationMessage.RequiredField)
            .Length(2, 100).WithMessage(ValidationMessage.LengthField);
    }
}