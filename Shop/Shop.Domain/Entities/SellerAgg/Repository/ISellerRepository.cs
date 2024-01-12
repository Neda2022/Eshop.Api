using Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.SellerAgg.Repository
{
    public interface ISellerRepository:IBaseRepository<Seller>
    {
        Task<InventoryResult> GetInventoryById(long Id);
    }
}
