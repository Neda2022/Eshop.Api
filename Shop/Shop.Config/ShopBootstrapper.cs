using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application._Utilites;
using Shop.Application.Categories;
using Shop.Application.Productes;
using Shop.Application.Productes.Create;
using Shop.Application.Roles.Create;
using Shop.Application.Roles.Edit;
using Shop.Application.Sellers;
using Shop.Application.Users;
using Shop.Domain.Entities.CategoryAgg.Services;
using Shop.Domain.Entities.ProductAgg.Repository;
using Shop.Domain.Entities.ProductAgg.Services;
using Shop.Domain.Entities.SellerAgg.Services;
using Shop.Domain.Entities.UserAgg.Services;
using Shop.Infrastructure;
using Shop.Presentation.Facade;
using Shop.Query.Categories.GetById;
using System.Reflection;

namespace Shop.Config;

    public static class ShopBootstrapper
    {
      public static void RegisterShopDependency(this IServiceCollection services, string connectionString)
    {
        InfrastructureBootstrapper.Init(services, connectionString);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Directories).GetTypeInfo().Assembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetCategoryByIdQuery).GetTypeInfo().Assembly));
        services.AddTransient<ICategoryDomainService, CategoryDomainService>();
        services.AddTransient<IProductDomainService, ProduductDomainService>();
        services.AddTransient<IDomainUserService, UserDomainService>();
        services.AddTransient<ISellerDomainService, SellerDomainService>();
        services.AddValidatorsFromAssembly(typeof(EditRoleCommandValidator).Assembly);
        services.InitFacadDependency();

    }
}

