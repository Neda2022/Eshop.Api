using Common.Application.Validation.FluentValidations;
using Common.Application.Validation;
using FluentValidation;
using Shop.Application.SiteEntities.Banners.Create;

namespace Shop.Application.SiteEntities.Sliders.Create;

public class CreateSlideCommandValidator : AbstractValidator<CreateSlideCommand>
{
    public CreateSlideCommandValidator()
    {
       
            RuleFor(b => b.ImageFile)
                .JustImageFile()
                .NotNull()
                .WithMessage(ValidationMessages.required("عکس"));
            RuleFor(b => b.Link)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("لینک"));

        RuleFor(b => b.Title)
               .NotNull()
               .NotEmpty()
               .WithMessage(ValidationMessages.required("عنوان"));

    }
}
