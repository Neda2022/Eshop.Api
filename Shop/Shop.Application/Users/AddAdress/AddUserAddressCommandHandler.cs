

using Common.Application;
using Shop.Domain.Entities.UserAgg;
using Shop.Domain.Entities.UserAgg.Repository;

namespace Shop.Application.Users.AddAdress;

internal class AddUserAddressCommandHandler : IBaseCommandHandler<AddUserAddressCommand>
{
    private readonly IUserRepository _repository;

    public AddUserAddressCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(AddUserAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.userId);
        if (user == null) return OperationResult.NotFound();
        var address = new UserAddress(request.Shire, request.City, request.PostalCode,
            request.PostalAddress, request.Name, 
            request.Family, request.NationalCode, request.PhoneNumber);
        user.AddAddress(address);
        await _repository.Save();
        return OperationResult.Success();

    }
}
