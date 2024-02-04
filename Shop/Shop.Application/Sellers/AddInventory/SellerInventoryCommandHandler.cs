

using Common.Application;
using Shop.Domain.Entities.SellerAgg;
using Shop.Domain.Entities.SellerAgg.Repository;

namespace Shop.Application.Sellers.AddInventory;

internal class SellerInventoryCommandHandler : IBaseCommandHandler<SellerInventoryCommand>
{
    private readonly ISellerRepository _repository;

    public SellerInventoryCommandHandler(ISellerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(SellerInventoryCommand request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetTracking(request.SellerId);
        if (seller == null) { return OperationResult.NotFound(); }
        var inventory = new SellerInventory(request.ProductId,
            request.Count,
            request.Price,
            request.PercentageDiscount);
        seller.AddInventory(inventory);
        await _repository.Save();
        return OperationResult.Success();
    }

}
