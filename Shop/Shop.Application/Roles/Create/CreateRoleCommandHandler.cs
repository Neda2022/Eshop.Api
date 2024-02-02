

using Common.Application;
using Shop.Domain.Entities.RoleAgg;
using Shop.Domain.Entities.RoleAgg.Repository;

namespace Shop.Application.Roles.Create;

internal class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
{
    private readonly IRoleRepository _repository;

    public CreateRoleCommandHandler(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var permissions = new List<RolePermission>();
        request.Permissions.ForEach( f=>
            {
                permissions.Add(new RolePermission());
        });
        var role = new Role(request.title, permissions);
         _repository.Add(role);
        await _repository.Save();
        return OperationResult.Success();
    }
}
