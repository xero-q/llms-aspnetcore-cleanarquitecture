using FluentValidation;
using Domain.Entities;
using LLMStudio;

namespace Domain.Validators;

public class ModelValidator:AbstractValidator<Model>
{
    public ModelValidator()
    {
        RuleFor(x => x.Temperature)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(1)
            .WithMessage(ErrorMessages.TemperatureBetweenZeroOne);
    }
}