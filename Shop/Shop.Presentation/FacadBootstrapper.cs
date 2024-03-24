
using Microsoft.Extensions.DependencyInjection;
using Shop.Presentation.Facade.Categories;
using Shop.Presentation.Facade.Comments;
using Shop.Presentation.Facade.Orders;
using Shop.Presentation.Facade.Products;
using Shop.Presentation.Facade.Roles;
using Shop.Presentation.Facade.Sellers;
using Shop.Presentation.Facade.Sellers.Inventories;
using Shop.Presentation.Facade.SiteEntities.Banner;
using Shop.Presentation.Facade.SiteEntities.Slider;
using Shop.Presentation.Facade.Users;
using Shop.Presentation.Facade.Users.Addresses;

namespace Shop.Presentation.Facade;

public static class FacadBootstrapper
    {
    public static void  InitFacadDependency(this IServiceCollection services)
    {
        services.AddScoped<ICategoryFacade, CategoryFacade>();
        services.AddScoped<ICommentFacad, CommentFacad>();
        services.AddScoped<IOrderFacad, OrderFacade>();
        services.AddScoped<IProductFacad, ProductFacad>();
        services.AddScoped<IRoleFacad, RoleFacade>();
        services.AddScoped<ISellerFacad, SellerFacad>();
        services.AddScoped<IBannerFacad, BannerFacad>();
        services.AddScoped<ISliderFacad, SliderFacad>();
        services.AddScoped<IUserFacad, UserFacad>();
        services.AddScoped<IUserAddressFacade, UserAddressFacade>();
        services.AddScoped<ISellerInventoryFacad, SellerInventoryFacad>();














    }
}

