using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.ChargeWallet;

public class ChargeUserWalletCommandValidator : AbstractValidator<ChargeUserWalletCommand>
{
    public ChargeUserWalletCommandValidator()
    {
        RuleFor(f => f.Description)
            .NotEmpty()
            .WithMessage(ValidationMessages.required("توضیحات"));
        RuleFor(f => f.Price)
            .GreaterThanOrEqualTo(1000);

    }
}