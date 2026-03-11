using Backend_Exam_Project.DTOs;
using FluentValidation;

namespace Backend_Exam_Project.Services.Ticket.Validations;

public class CreateTicketValidation : AbstractValidator<CreateTicketDTO>
{
    public CreateTicketValidation()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(x => x.Description)
            .NotEmpty();

        RuleFor(x => x.Priority)
            .NotEmpty()
            .Must(priority => new[] { "Low", "Medium", "High" }.Contains(priority))
            .WithMessage("Priority must be Low, Medium, or High.");
    }
}
