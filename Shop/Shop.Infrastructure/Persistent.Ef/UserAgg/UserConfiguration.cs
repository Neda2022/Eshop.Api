﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.UserAgg;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "User");
        builder.HasIndex(b => b.PhoneNumber)
            .IsUnique();

        builder.Property(b => b.Email)
               .IsRequired(false);

        builder.Property(b=>b.Name)
            .HasMaxLength(80)
            .IsRequired(false);

        builder.Property(b => b.Family)
            .HasMaxLength(80)
            .IsRequired(false);

        builder.Property(b => b.Password)
            .HasMaxLength(80)
            .IsRequired();


        builder.OwnsMany(b => b.Tokens, option =>
        {
            option.ToTable("Tokens", "user");
            option.HasKey(b => b.Id);

            option.Property(b => b.HashJwtToken)
                .IsRequired()
                .HasMaxLength(250);

            option.Property(b => b.HashRefreshToken)
                .IsRequired()
                .HasMaxLength(250);

            option.Property(b => b.Device)
                .IsRequired()
                .HasMaxLength(100);
        });

        builder.OwnsMany(b => b.Addresses, option =>
        {
            option.HasIndex(b => b.UserId);
            option.ToTable("Addresses", "user");

            option.Property(b => b.Shire)
                 .IsRequired().HasMaxLength(100);

            option.Property(b => b.City)
                .IsRequired().HasMaxLength(100);

            option.Property(b => b.Name)
               .IsRequired().HasMaxLength(50);

            option.Property(b => b.Family)
                .IsRequired().HasMaxLength(50);


            option.Property(b => b.NationalCode)
                .IsRequired().HasMaxLength(10);

            option.Property(b => b.PostalCode)
                .IsRequired().HasMaxLength(20);

            option.OwnsOne(c => c.PhoneNumber, config =>
            {
                config.Property(b => b.Value)
                    .HasColumnName("PhoneNumber")
                    .IsRequired().HasMaxLength(11);
            });
        });


        builder.OwnsMany(b => b.Wallets, option =>
        {
            option.ToTable("Wallets", "user");
            option.HasIndex(b => b.UserId);

            option.Property(b => b.Description)
                .IsRequired(false)
                .HasMaxLength(500);
        });

        builder.OwnsMany(b => b.Roles, option =>
        {
            option.ToTable("Roles", "user");
            option.HasIndex(b => b.UserId);
        });



        builder.Property(b => b.PhoneNumber)
            .HasMaxLength(11)
            .IsRequired();
        //builder.Property(b => b.Email)
        //    .HasMaxLength(256)
        //    .IsRequired();
    }
}
