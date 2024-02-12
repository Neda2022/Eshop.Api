using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.OrderAgg
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "order");

            // Value Object تنظیمات 
            builder.OwnsOne(b => b.Discount, option =>
            {
                option.Property(b => b.DiscountTitle)
                .HasMaxLength(50);
            });

            // Value Object تنظیمات 
            builder.OwnsOne(b => b.ShippingMethod, option =>
            {
                option.Property(b => b.ShippingType)
                .HasMaxLength(50);
            });
            // استفاده میکنیم ownMany   وقتی رابطه چند به چند داریم از        
            builder.OwnsMany(b=>b.Items, option=>{
                option.ToTable("Item", "order");
            });

            // استفاده می کنیم  ownOne وقتی رابطه یک به یک استفاده می کنیم از 
            builder.OwnsOne(b => b.Address, option =>
            {
                option.ToTable("Address", "order");
                option.HasKey(b=>b.Id);
                option.Property(b => b.City)
                .HasMaxLength(50)
                .IsRequired();

                option.Property(b => b.PhoneNumber)
                .HasMaxLength(50)
                .IsRequired(); 

                option.Property(b => b.Family)
                .HasMaxLength(50)
                .IsRequired();

                option.Property(b => b.Name)
                .HasMaxLength(50)
                .IsRequired();

                option.Property(b => b.PhoneNumber)
                .HasMaxLength(11)
                .IsRequired();

                option.Property(b => b.PostalCode)
                .HasMaxLength(30)
                .IsRequired();

                option.Property(b => b.PostalAddress)
                .HasMaxLength(30)
                .IsRequired();







            });
        }
    }
}
