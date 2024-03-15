
using Shop.Domain.Entities.UserAgg;
using Shop.Domain.Entities.UserAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.UserAgg;

internal class UserRepository : BaseRepository<User>,IUserRepository
{
    public UserRepository(ShopContext context) : base(context)
    {
    }
}
