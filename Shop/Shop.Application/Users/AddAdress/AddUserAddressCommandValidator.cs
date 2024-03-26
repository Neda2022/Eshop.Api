using Common.Application.Validation;
using FluentValidation;
using Shop.Application.Users.EditAddress;

namespace Shop.Application.Users.AddAdress;

public class EditAddressCommandValidator:AbstractValidator<EditAddressCommand>
{
    public EditAddressCommandValidator()
    {
        RuleFor(f => f.Shire)
            .NotEmpty()
            .WithMessage(ValidationMessages.required("استان"));
        RuleFor(f => f.City)
            .NotEmpty()
            .WithMessage(ValidationMessages.required("شهر"));
        RuleFor(f => f.PostalCode)
            .NotEmpty()
            .NotNull()
            .WithMessage(ValidationMessages.required("کدپستی"));
       
        RuleFor(f => f.PostalAddress)
            .NotEmpty()
            .NotNull()
            .WithMessage(ValidationMessages.required("آدرس پستی"));
        RuleFor(f => f.Name)
            .NotEmpty()
            .WithMessage(ValidationMessages.required("نام")); 
        
        RuleFor(f => f.Family)
            .NotEmpty()
            .WithMessage(ValidationMessages.required("نام خانوادگی"));
       
    }
}