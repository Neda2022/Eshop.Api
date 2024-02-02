

using Common.Application;
using Shop.Domain.Entities.RoleAgg.Enums;

namespace Shop.Application.Roles.Create;

public record CreateRoleCommand(string title , List<Permission> Permissions):IBaseCommand;
