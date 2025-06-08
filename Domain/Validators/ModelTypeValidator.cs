using Domain.Entities;
using FluentValidation;
using LLMStudio;

namespace Domain.Validators;

public class ModelTypeValidator:AbstractValidator<ModelType>
{
    public ModelTypeValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ErrorMessages.ModelTypeNameNotEmpty);
    }
}