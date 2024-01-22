

using Common.Application;
using FluentValidation.Validators;
using Shop.Domain.Entities.OrderAgg;
using Shop.Domain.Entities.OrderAgg.Repository;
using Shop.Domain.Entities.SellerAgg;
using Shop.Domain.Entities.SellerAgg.Repository;

namespace Shop.Application.Orders.AddItem;

public record AddItemOrderCommand(long InventoryId, int Count, long UserId) :IBaseCommand;

public class AddItemOrderCommandHandler : IBaseCommandHandler<AddItemOrderCommand>
{
    private readonly IOrderRepository _repository;
    private readonly ISellerRepository _sellerRepository;

    public AddItemOrderCommandHandler(IOrderRepository repository, ISellerRepository sellerRepository)
    {
        _repository = repository;
        _sellerRepository = sellerRepository;
    }

    public async Task<OperationResult> Handle(AddItemOrderCommand request, CancellationToken cancellationToken)
    {
        var inventory = await _sellerRepository.GetInventoryById(request.InventoryId);
        if (inventory == null)
            return OperationResult.NotFound();

        //اگر مشتری سفارش بیشتر از حد نصاب داد
        if(inventory.Count<request.Count)
            return OperationResult.Error("بیشتر از حد نصاب در خواست کردید!");


        //اگر سفارشی بود که هنوز به مرحله فاینالی نرسیده
        var order = await _repository.GetCurrentUserOrder(request.UserId);
        
        //  اگر سفارش جدید یا یک کالای دیگه رو انتخاب کرد 
        if(order==null)
        {
            order = new Order(request.UserId);
        }

        // اگر سفارش درخواستی در سبد خرید از قبل وجود داشت دیگه نباید کد زیر بزاریم  

        order.AddItem(new OrderItem(request.InventoryId,request.Count, inventory.Price));
        //پس اینکه آیتم اد کرد
        if(ItemCountBiggerThanInventoryCount(inventory, order))
        {
            return OperationResult.Error("بیشتر از حد نصاب در خواست کردید!");
        }

        await  _repository.Save();
        return OperationResult.Success();
    }

    private bool ItemCountBiggerThanInventoryCount(InventoryResult Inventory, Order order)
    {

        var orderItem = order.Items.First(f => f.InventoryId == Inventory.Id);
        if(orderItem.Count>Inventory.Count)
            return true;
        return false;
    }
}
