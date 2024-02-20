using Dapper;
using Shop.Domain.Entities.SellerAgg;
using Shop.Domain.Entities.SellerAgg.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.SellerAgg
{
    public class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        private readonly DapperContext _dapperContext;
        public SellerRepository(ShopContext context) : base(context)
        {
        }

        public async Task<InventoryResult?> GetInventoryById(long id)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = $"SELECt * from {_dapperContext.Inventories} Where Id= @InventoryId";
          return  await connection.QueryFirstOrDefaultAsync<InventoryResult>(sql , new { InventoryId = id});

        }
    }
}
