﻿using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.Entities.SellerAgg;

public class SellerInventory:BaseEntity
{
    public SellerInventory( long productId,
        int count, int price, int? percentageDiscount =null)
    {
        if (price < 1 || count < 0)
            throw new InvalidDomainDataException();

        ProductId = productId;
        Count = count;
        Price = price;
        PercentageDiscount = percentageDiscount;
    }

    public long SellerId { get; private set; }
    public long ProductId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int? PercentageDiscount { get; private set; }

    public void Edit(int count, int price, int? percentageDiscount = null)
    {
        Count = count;
        Price = price;
        PercentageDiscount = percentageDiscount;
    }
}
