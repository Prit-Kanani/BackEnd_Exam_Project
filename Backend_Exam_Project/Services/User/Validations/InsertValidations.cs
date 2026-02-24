using Backend_Exam_Project.DTOs;
using FluentValidation;

namespace Backend_Exam_Project.Services.User.Validations;

public class InsertValidations : AbstractValidator<CreateUserDTO>
{
    public InsertValidations()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .MaximumLength(255).WithMessage("Email must be less then 255 charectors.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
    }
}
