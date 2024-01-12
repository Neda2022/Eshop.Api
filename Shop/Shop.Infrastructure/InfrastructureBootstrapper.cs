using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure.Persistent.Ef.UserAgg;
using Common.Domain.Repository;
using Shop.Domain.Entities.UserAgg.Repository;
using Shop.Domain.Entities.OrderAgg.Repository;
using Shop.Infrastructure.Persistent.Ef.OrderAgg;
using Shop.Domain.Entities.RoleAgg.Repository;
using Shop.Infrastructure.Persistent.Ef.RoleAgg;
using Shop.Domain.Entities.SellerAgg.Repository;

namespace Shop.Infrastructure;

public class InfrastructureBootstrapper
{
        public static void Init(IServiceCollection services, string connectionString)
    {

        services.AddTransient<IUsrerRepository, UserRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<ISellerRepository, ISellerRepository>();



    }



}


