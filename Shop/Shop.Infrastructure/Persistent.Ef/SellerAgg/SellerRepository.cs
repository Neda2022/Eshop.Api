using Shop.Domain.Entities.SellerAgg;
using Shop.Domain.Entities.SellerAgg.Repository;
using Shop.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.SellerAgg
{
    public class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        public SellerRepository(ShopContext context) : base(context)
        {
        }

        public Task<InventoryResult> GetInventoryById(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
