using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.AddChild;

public class AddChidCategoryCommandValidator : AbstractValidator<AddChidCategoryCommand>
{
    public AddChidCategoryCommandValidator()
    {
        RuleFor(r => r.Title)
        .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

        RuleFor(r => r.Slug)
      .NotNull().NotEmpty().WithMessage(ValidationMessages.required("slug"));

    }
}

