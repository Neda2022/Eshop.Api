using FluentValidation;

namespace Shop.Application.Orders.DeacreaseItemCount;

public class DecreaseOrderItemCountCommandValidator : AbstractValidator<DecreaseOrderItemCountCommand>
{
    public DecreaseOrderItemCountCommandValidator()
    {

        RuleFor(f => f.Count)
        .GreaterThanOrEqualTo(1).WithMessage("مقدار باید بیشتر از 0 باشد");
    }
}


