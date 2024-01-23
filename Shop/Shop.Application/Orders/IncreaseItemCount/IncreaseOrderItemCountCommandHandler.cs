
using Common.Application;
using Shop.Domain.Entities.OrderAgg.Repository;

namespace Shop.Application.Orders.ChangeCount;

public class IncreaseOrderItemCountCommandHandler : IBaseCommandHandler<IncreaseOrderItemCount>
{
    private readonly IOrderRepository _repository;

    public IncreaseOrderItemCountCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(IncreaseOrderItemCount request, CancellationToken cancellationToken)
    {
        var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
        if (currentOrder == null)
        {
            return OperationResult.NotFound();
        }

        currentOrder.IncreaseItemCount(request.ItemId, request.Count);
        await _repository.Save();
        return OperationResult.Success();

    }
}
