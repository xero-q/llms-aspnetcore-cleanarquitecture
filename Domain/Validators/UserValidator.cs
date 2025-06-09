using FluentValidation;
using Domain.Entities;
using SharedKernel;

namespace Domain.Validators;

public class UserValidator:AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x=>x.Username).NotEmpty().WithMessage(ErrorMessages.UsernameNotEmpty);

        RuleFor(x => x.Password).NotEmpty().WithMessage(ErrorMessages.PasswordNotEmpty);
    }
}