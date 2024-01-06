using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.Entities.UserAgg.Services;
using Shop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Config;

    public static class ShopBootstrapper
    {
      public static void RegisterShopDependency(this IServiceCollection services)
    {
        //InfrastructureBootstrapper.Init(services, connectionString);
        //services.AddTransient<IDomainUserService, UserDomainService>();

    }
    }

