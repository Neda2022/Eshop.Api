using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.SiteEntities.Banners.Create;

public class CreateBannerValidator : AbstractValidator<CreateBannerCommand>
{
    public CreateBannerValidator()
    {
        RuleFor(b => b.ImageFile)
            .JustImageFile()
            .NotNull()
            .WithMessage(ValidationMessages.required("عکس"));
        RuleFor(b => b.Link)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("لینک"));
    }
}