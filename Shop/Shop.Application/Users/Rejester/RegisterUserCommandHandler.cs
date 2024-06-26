﻿

using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.Entities.UserAgg;
using Shop.Domain.Entities.UserAgg.Repository;
using Shop.Domain.Entities.UserAgg.Services;
using Shop.Infrastructure.Persistent.Ef;

namespace Shop.Application.Users.Rejester;

internal class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
{
    private readonly IUserRepository _repository;
    private readonly IDomainUserService _domainUser;
    private readonly ShopContext _context;

    public RegisterUserCommandHandler(IUserRepository repository, IDomainUserService domainUser)
    {
        _repository = repository;
        _domainUser = domainUser;
        
    }

    public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.RegisterUser(request.PhoneNumber.Value, Sha256Hasher.Hash(request.Password), _domainUser);
      
        _repository.Add(user);

        await _repository.Save();
        return OperationResult.Success();




    }
}
