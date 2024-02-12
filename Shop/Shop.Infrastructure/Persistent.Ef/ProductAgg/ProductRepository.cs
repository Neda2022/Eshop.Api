using Shop.Domain.Entities.ProductAgg;
using Shop.Domain.Entities.ProductAgg.Repository;
using Shop.Infrastructure._Utilities;


namespace Shop.Infrastructure.Persistent.Ef.ProductAgg
{
    internal class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {
        }
    }
}
