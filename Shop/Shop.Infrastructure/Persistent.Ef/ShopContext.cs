﻿using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.CategoryAgg;
using Shop.Domain.Entities.CommentAgg;
using Shop.Domain.Entities.OrderAgg;
using Shop.Domain.Entities.ProductAgg;
using Shop.Domain.Entities.RoleAgg;
using Shop.Domain.Entities.SellerAgg;
using Shop.Domain.Entities.SiteEntity;
using Shop.Domain.Entities.UserAgg;

namespace Shop.Infrastructure.Persistent.Ef;

public class ShopContext : DbContext
{
    public ShopContext(DbContextOptions<ShopContext> options)
        : base(options)
    {

    }
   
   
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> products { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Slider> Slider { get; set; }
    public DbSet<Banner> Banner { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

}

