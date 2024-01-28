using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Productes.Edit;

public class EditProductCommandAValidator : AbstractValidator<EditProductCommand>
{
    public EditProductCommandAValidator()
    {
        RuleFor(f => f.Title)
   .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

        RuleFor(f => f.Description)
       .NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));

        RuleFor(f => f.ImageFile)
       .JustImageFile();

        RuleFor(f => f.Slug)
         .NotEmpty().WithMessage(ValidationMessages.required("Slug"));

    }
}



