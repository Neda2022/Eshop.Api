using Shop.Domain.Entities.OrderAgg;
using Shop.Domain.Entities.OrderAgg.Repository;
using Shop.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.OrderAgg;

    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DataBaseContext context) : base(context)
        {
        }

        public Task<Order> GetCurrentUserOrder(long UserId)
        {
            throw new NotImplementedException();
        }
    }

