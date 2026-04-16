using FluentValidation;

namespace TaskBoard.Application.Commands.Auth;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username is required.")
            .MaximumLength(50).WithMessage("Username should be less than 50 characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password should be at least 6 characters.");
    }
}
