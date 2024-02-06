using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Create;

public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        

        RuleFor(f => f.Email)
                   .EmailAddress()
                   .WithMessage("   ایمیل نامعتبر است");
        RuleFor(f => f.PhoneNumber)
            .ValidPhoneNumber();
    
        RuleFor(f => f.Password)
                   .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
                   .NotNull().WithMessage(ValidationMessages.required("کلمه عبور"))
                   .MinimumLength(4)
                   .WithMessage("کلمه عبور باید بیشتر از 4 کاراکتر باشد!");
    }
}