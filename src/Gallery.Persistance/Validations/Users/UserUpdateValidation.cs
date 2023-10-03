using FluentValidation;
using Gallery.Persistance.Dtos.Users;

namespace Gallery.Persistance.Validations.Users;

public class UserUpdateValidation : AbstractValidator<UserUpdateDto>
{
    public UserUpdateValidation()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Firstname field is required !")
            .MinimumLength(3).WithMessage("Firstname must be more than 3 characters")
            .MaximumLength(30).WithMessage("Firstname must be less than 30 characters");

        RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Lastname field is required !")
            .MinimumLength(3).WithMessage("Lastname must be more than 3 characters")
            .MaximumLength(30).WithMessage("Lastname must be less than 30 characters");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required !")
            .MinimumLength(20).WithMessage("Name must be more than 20 characters");
    }
}