using Common.Domain;
using Shop.Domain.Entities.RoleAgg.Enums;

namespace Shop.Domain.Entities.RoleAgg;

public class RolePermission : BaseEntity
{
    public long RoleId { get; private set; }
    public Permission Permission { get; private set; }


}
