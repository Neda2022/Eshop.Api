using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure.Persistent.Ef.UserAgg;
using Common.Domain.Repository;
using Shop.Domain.Entities.UserAgg.Repository;
using Shop.Domain.Entities.OrderAgg.Repository;
using Shop.Infrastructure.Persistent.Ef.OrderAgg;
using Shop.Domain.Entities.RoleAgg.Repository;
using Shop.Infrastructure.Persistent.Ef.RoleAgg;
using Shop.Domain.Entities.SellerAgg.Repository;
using Shop.Infrastructure.Persistent.Ef.SellerAgg;
using Shop.Domain.Entities.ProductAgg.Repository;
using Shop.Infrastructure.Persistent.Ef.ProductAgg;
using Shop.Infrastructure.Persistent.Ef.CategoryAgg;
using Shop.Domain.Entities.CategoryAgg.Repository;
using Shop.Infrastructure.Persistent.Ef.CommentAgg;
using Shop.Domain.Entities.CommentAgg.Repository;
using Shop.Domain.Entities.SiteEntity.Repository;
using Shop.Infrastructure.Persistent.Ef.SiteEntities.Repository;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastructure;

public class InfrastructureBootstrapper
{
        public static void Init(IServiceCollection services, string connectionString)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<ICommentRepository, CommentRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<ISellerRepository, SellerRepository>();
        services.AddTransient<IBannerRepository, BannerRepository>();
        services.AddTransient<ISliderRepository, SliderRepository>();
       // services.AddTransient<IShippingMethodRepository, ShippingMethodRepository>();
        services.AddTransient<DapperContext>(_=> new DapperContext(connectionString));
        services.AddTransient(_ => new DapperContext(connectionString));
        services.AddDbContext<ShopContext>(option =>
        {
            option.UseSqlServer(connectionString);
        });
    }


}






