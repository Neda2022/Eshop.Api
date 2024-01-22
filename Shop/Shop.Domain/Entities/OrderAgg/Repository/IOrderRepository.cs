using Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.OrderAgg.Repository;

    public interface IOrderRepository:IBaseRepository<Order>
    {
    //سفارشی که هنوز فاینالی نشده و هنوز فعاله
     Task<Order> GetCurrentUserOrder(long UserId);
    }

