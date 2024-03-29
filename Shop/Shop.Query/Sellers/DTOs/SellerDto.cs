﻿

using Common.Query;
using Shop.Domain.Entities.SellerAgg;

namespace Shop.Query.Sellers.DTOs;

public class SellerDto:BaseDto
    {
    public long UserId { get;  set; }
    public string ShopName { get;  set; }
    public string NationalCode { get;  set; }
    public SellerStatus Status { get;  set; }
}
