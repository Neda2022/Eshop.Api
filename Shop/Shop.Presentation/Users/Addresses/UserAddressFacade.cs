


using Common.Application;
using MediatR;
using Shop.Application.Users.AddAdress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;
using Shop.Domain.Entities.UserAgg;
using Shop.Query.Users.Addresses.GetById;
using Shop.Query.Users.Addresses.GetList;
using Shop.Query.Users.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Presentation.Facade.Users.Addresses;

internal class UserAddressFacade : IUserAddressFacade
{


    private readonly IMediator _mediator;

    public UserAddressFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddAddress(AddUserAddressCommand command)
    {
        return await _mediator.Send(command);
    }

    public Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command)
    {
        throw new NotImplementedException();
    }

    public async Task<OperationResult> EditAddress(EditAddressCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<AddressDto?> GetById(long UserAddressId)
    {
        return await _mediator.Send(new GetUserAddressByIdQuery(UserAddressId));
    }

    public async Task<List<AddressDto>> GetList(long UserId)
    {
        return await _mediator.Send(new GetUserAddressesListQuery(UserId));


    }
}