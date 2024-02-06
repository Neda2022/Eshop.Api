

using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.Entities.UserAgg;
using Shop.Domain.Entities.UserAgg.Repository;
using Shop.Domain.Entities.UserAgg.Services;

namespace Shop.Application.Users.Create;

internal class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
{
  private readonly  IUsrerRepository _repository;
    private readonly IDomainUserService _domainService;

    public CreateUserCommandHandler(IUsrerRepository repository, IDomainUserService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var password = Sha256Hasher.Hash(request.Password);
        var user = new User(request.Name, request.Family, request.PhoneNumber,
            request.Email, password
            , request.Gender, _domainService);
        _repository.Add(user);
        await _repository.Save();
        return OperationResult.Success();
    }
}
