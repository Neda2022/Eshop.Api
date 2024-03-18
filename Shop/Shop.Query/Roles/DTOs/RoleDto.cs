

using Common.Query;
using Shop.Domain.Entities.RoleAgg.Enums;

namespace Shop.Query.Roles.DTOs;

    public class RoleDto:BaseDto
    {
    public string  Title { get; set; }
    public List<Permission>  permissions{ get; set; }

}

