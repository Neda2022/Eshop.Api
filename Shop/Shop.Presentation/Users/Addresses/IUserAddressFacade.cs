


using Common.Application;
using Shop.Application.Users.AddAdress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;

using Shop.Query.Users.DTOs;

namespace Shop.Presentation.Facade.Users.Addresses;

public interface IUserAddressFacade
    {
    Task<OperationResult> AddAddress(AddUserAddressCommand command);
    Task<OperationResult> EditAddress(EditAddressCommand command);
    Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command);
    Task<AddressDto?> GetById(long UserAddressId);
    Task<List<AddressDto>> GetList(long UserId);





}
