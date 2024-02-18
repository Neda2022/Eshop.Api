using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.OrderAgg.Repository;
using Shop.Domain.Entities.RoleAgg;
using Shop.Domain.Entities.RoleAgg.Repository;
using Shop.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.RoleAgg
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", "role");
            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(60);

            builder.OwnsMany(b => b.Permission, option =>
            {
                option.ToTable("Permissions", "role");
            });
        }
    }



}
