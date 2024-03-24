


using Common.Application;
using Shop.Application.Users.AddAdress;
using Shop.Application.Users.EditAddress;

namespace Shop.Presentation.Facade.Users.Addresses;

public interface IUserAddressFacade
    {
    Task<OperationResult> AddAddress(AddUserAddressCommand command);
    Task<OperationResult> EditAddress(EditAddressCommand command);



}
