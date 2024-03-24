

using Common.Application;
using MediatR;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.EditInventory;

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
}