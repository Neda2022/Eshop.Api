using Shop.Domain.Entities.SiteEntity;
using Shop.Domain.Entities.SiteEntity.Repository;
using Shop.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities.Repository
{
    internal class BannerRepository : BaseRepository<Banner>, IBannerRepository
    {
        public BannerRepository(ShopContext context) : base(context)
        {
        }
    }
}
