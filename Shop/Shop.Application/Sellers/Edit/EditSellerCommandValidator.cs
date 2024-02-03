using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Sellers.Edit;

public class EditSellerCommandValidator:AbstractValidator<EditSellerCommand>
{
    public EditSellerCommandValidator()
    {
        RuleFor(s => s.ShopName)
           .NotEmpty()
           .WithMessage(ValidationMessages.required("فروشگاه"));

        RuleFor(s => s.NationalCode)
            .NotEmpty()
            .WithMessage(ValidationMessages.required("کدملی"))
            .ValidNationalId();


    }
}