using Domain.Entities;
using FluentValidation;
using SharedKernel;

namespace Domain.Validators;

public class ModelTypeValidator:AbstractValidator<ModelType>
{
    public ModelTypeValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ErrorMessages.ModelTypeNameNotEmpty);
    }
}