

using Common.Application;
using MediatR;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.EditInventory;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.Inventories.GetById;
using Shop.Query.Sellers.Inventories.GetList;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Presentation.Facade.Sellers.Inventories;

internal class SellerInventoryFacad : ISellerInventoryFacad
{
    private readonly IMediator _mediaor;

    public SellerInventoryFacad(IMediator mediaor)
    {
        _mediaor = mediaor;
    }

    public async Task<OperationResult> AddInventory(AddSellerInventoryCommand command)
    {
       return  await _mediaor.Send(command);
            
            }

    public async Task<OperationResult> EditInventory(EditInventoryCommand command)
    {
        return await _mediaor.Send(command);
    }

    public async Task<InventoryDto?> GetById(long inventoryId)
    {
        return await _mediaor.Send(new GetSellerInventoryByIdQuery(inventoryId));
    }

    public async Task<List<InventoryDto>> GetByList(long sellerId)
    {
        return await _mediaor.Send(new GetInventoriesQuery(sellerId));
    }

   
}