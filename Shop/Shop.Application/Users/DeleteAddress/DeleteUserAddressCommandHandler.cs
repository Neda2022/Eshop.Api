﻿

using Common.Application;
using Shop.Domain.Entities.UserAgg.Repository;

namespace Shop.Application.Users.DeleteAddress;

internal class DeleteUserAddressCommandHandler : IBaseCommandHandler<DeleteUserAddressCommand>
{
    private readonly IUserRepository _repository;

    public DeleteUserAddressCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(DeleteUserAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);

        if (user == null)
        OperationResult.NotFound(); 

        else {
            user.DeleteAddress(request.AddressId);
        }
       
        await _repository.Save();
        return OperationResult.Success();
        
        
    }
}