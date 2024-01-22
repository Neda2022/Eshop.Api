using FluentValidation;

namespace Shop.Application.Orders.AddItem;

public class AddItemOrderCommandHandlerValidator:AbstractValidator<AddItemOrderCommand>
{
    public AddItemOrderCommandHandlerValidator()
    {
        RuleFor(f => f.Count)
        .GreaterThanOrEqualTo(1).WithMessage("مقدار باید بیشتر از 0 باشد");
    }
}
