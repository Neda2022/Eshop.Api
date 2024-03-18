

using Common.Query;
using Shop.Domain.Entities.RoleAgg;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles.GetByList;

public record GetRoleListQuery:IQuery<List<RoleDto>>;


