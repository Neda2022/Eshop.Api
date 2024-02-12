

using Common.Application;
using Shop.Domain.Entities.UserAgg;
using Shop.Domain.Entities.UserAgg.Repository;

namespace Shop.Application.Users.AddAdress;

internal class EditAddressCommandHandler : IBaseCommandHandler<EditAddressCommand>
{
    private readonly IUserRepository _repository;

    public EditAddressCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditAddressCommand request, CancellationToken cancellationToken)
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
