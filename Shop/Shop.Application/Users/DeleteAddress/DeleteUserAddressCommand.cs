

using Common.Application;
using Shop.Application.Users.DeleteAddress;

namespace Shop.Application.Users.DeleteAddress;

public record DeleteUserAddressCommand(long AddressId, long UserId):IBaseCommand;
