using FluentValidation;
using Common.Application.Validation;

namespace Shop.Application.Categories.Create;

public class CreatCategryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreatCategryCommandValidator()
    {
        RuleFor(r => r.Title)
        .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

        RuleFor(r => r.Slug)
      .NotNull().NotEmpty().WithMessage(ValidationMessages.required("slug"));
    }
}

