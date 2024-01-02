

using Common.Domain;

namespace Shop.Domain.Entities.UserAgg;

public class UserRole : BaseEntity
{
    private UserRole()
    {
            
    }
    public UserRole(long roleId)
    {
        RoleId = roleId;
    }

    public long UserId { get; internal set; }

    public long RoleId { get;private set; }
}

