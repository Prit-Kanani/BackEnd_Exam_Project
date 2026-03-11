using Backend_Exam_Project.DTOs;
using FluentValidation;

namespace Backend_Exam_Project.Services.Role.Validations;

public class CreateRoleValidation : AbstractValidator<CreateRoleDTO>
{
    public CreateRoleValidation()
    {
        RuleFor(x => x.RoleName)
            .NotEmpty()
            .MaximumLength(20)
            .Must(role => new[] { "Manager", "Support", "User" }.Contains(role))
            .WithMessage("RoleName must be Manager, Support, or User.");
    }
}
