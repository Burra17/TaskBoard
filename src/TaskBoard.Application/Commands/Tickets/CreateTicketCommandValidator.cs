using FluentValidation;

namespace TaskBoard.Application.Commands.Tickets;

public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
{
    public CreateTicketCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title should be less then 100 characters.");

        RuleFor(x => x.Priority)
            .IsInEnum().WithMessage("Invalid priority value.");

        RuleFor(x => x.ProjectId)
            .NotEmpty().WithMessage("ProjectId is required.");
    }
}
