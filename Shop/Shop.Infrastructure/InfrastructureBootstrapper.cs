using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure.Persistent.Ef.UserAgg;
using Common.Domain.Repository;
using Shop.Domain.Entities.UserAgg.Repository;

namespace Shop.Infrastructure;

    public class InfrastructureBootstrapper
{
        public static void Init(IServiceCollection services, string connectionString)
    {
        services.AddTransient<IUsrerRepository, UserRepository>();

    }
           


    }


