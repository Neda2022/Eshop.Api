﻿using System.Runtime.CompilerServices;

namespace Shop.Api.Infrastructure
{
    public static class DependencyRegister
    {
        public static void RegisterApiDependency(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            services.AddCors(options =>
            {
                options.AddPolicy(name: "ShopApi",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
        }
    }
}
