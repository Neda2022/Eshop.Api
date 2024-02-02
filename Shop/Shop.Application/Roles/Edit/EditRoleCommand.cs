

using Common.Application;
using Shop.Domain.Entities.RoleAgg;
using Shop.Domain.Entities.RoleAgg.Enums;
using Shop.Domain.Entities.RoleAgg.Repository;

namespace Shop.Application.Roles.Edit;

public record EditRoleCommand(long Id,string title, List<Permission> Permissions) : IBaseCommand;

internal class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
{
    private readonly IRoleRepository _repository;

    public EditRoleCommandHandler(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _repository.GetTracking(request.Id);
        if (role == null) { return OperationResult.NotFound(); }
        role.Edit(request.title);
        var permissions = new List<RolePermission>();
        request.Permissions.ForEach(f =>
        {
            permissions.Add(new RolePermission());
        });
        role.SetPermissions(permissions);
        await _repository.Save();
        return OperationResult.Success();
    }
}

