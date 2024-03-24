

using Shop.Domain.Entities.SellerAgg;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers;

public static class SellerMapper
{
    public static SellerDto? Map(this Seller seller)
    {
        return new SellerDto()
        {
            Id = seller.Id,
            CreationDate=seller.CreateDate,
            NationalCode=seller.NationalCode,
            ShopName=seller.ShopName,
            Status=seller.Status,   
            UserId = seller.UserId,

        };
    }
    public static SellerDto MapList(this Seller seller)
    {
        return new SellerDto()
        {
            Id = seller.Id,
            CreationDate = seller.CreateDate,
            NationalCode = seller.NationalCode,
            ShopName = seller.ShopName,
            Status = seller.Status,
            UserId = seller.UserId,

        };
    }
}
    

