

using Common.Application;
using Shop.Domain.Entities.UserAgg;
using Shop.Domain.Entities.UserAgg.Repository;

namespace Shop.Application.Users.EditAddress;

internal class EditAddressCommandHandler : IBaseCommandHandler<EditAddressCommand>
{
    private readonly IUserRepository _repository;

    public EditAddressCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null) return OperationResult.NotFound();
        var address = new UserAddress(request.Shire, request.City, request.PostalCode,
            request.PostalAddress, request.Name, 
            request.Family, request.NationalCode, request.PhoneNumber);
        user.EditAddress(address, request.Id);
        await _repository.Save();
        return OperationResult.Success();

    }
}
