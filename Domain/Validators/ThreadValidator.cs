using FluentValidation;
using Domain.Entities;
using SharedKernel;

using Thread = Domain.Entities.Thread;

namespace Domain.Validators;

public class ThreadValidator:AbstractValidator<Thread>
{
    public ThreadValidator()
    {
        RuleFor(x=>x.Title).NotEmpty().WithMessage(ErrorMessages.ThreadTitleNotEmpty);
    }
}