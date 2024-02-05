using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;
using Shop.Application.SiteEntities.Banners.Create;

namespace Shop.Application.SiteEntities.Banners.Edit;

public class EditBannerValidator : AbstractValidator<CreateBannerCommand>
{
    public EditBannerValidator()
    {
        RuleFor(b => b.ImageFile)
             .JustImageFile();

        RuleFor(b => b.ImageFile)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("لینک"));
    }
}