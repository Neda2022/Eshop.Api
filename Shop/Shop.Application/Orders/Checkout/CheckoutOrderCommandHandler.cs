

using Common.Application;
using Shop.Domain.Entities.OrderAgg;
using Shop.Domain.Entities.OrderAgg.Repository;

namespace Shop.Application.Orders.Checkout;

public class CheckoutOrderCommandHandler : IBaseCommandHandler<CheckoutOrderCommand>
{
    private readonly IOrderRepository _repository;

    public CheckoutOrderCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
        if (currentOrder == null) 
        {
            return OperationResult.NotFound();
        }

        var address = new OrderAddress(
            request.Shir,
            request.PhoneNumber,
            request.Family,
            request.City,
            request.Name,
            request.NationalCode,
            request.PostalAddress,
            request.PostalCode);

        currentOrder.CheckOut(address);
        await _repository.Save();
        return OperationResult.Success();
    }
}



