using FluentValidation;
using Gallery.Persistance.Dtos.Auth;

namespace Gallery.Persistance.Validations.Auth;

public class LoginValidation : AbstractValidator<LoginDto>
{
    public LoginValidation()
    {
        RuleFor(dto => dto.Email).Must(email => EmailValidator.IsValid(email))
            .WithMessage("Email addres is invalid! example@gmail.com");

        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong password!");
    }
}