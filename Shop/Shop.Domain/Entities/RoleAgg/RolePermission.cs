using Common.Domain;
using Shop.Domain.Entities.RoleAgg.Enums;

namespace Shop.Domain.Entities.RoleAgg;

public class RolePermission : BaseEntity
{
    public long RoleId { get; internal set; }
    public Permission Permission { get; private set; }


}
