

using Dapper;
using Shop.Domain.Entities.OrderAgg;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders;

    internal static class OrderMapper
    {
     public static OrderDto  Map(this Order order)
    {
        if (order == null)
            return null;
        return new OrderDto()
        {
            CreationDate = order.CreateDate,
            Id = order.Id,
            Status = order.Status,
            Address = order.Address,
            Discount = order.Discount,
            Items = new(),
            LastUpdate = order.LastUpdate,
            ShippingMethod = order.ShippingMethod,
            UserFullName = "",
            UserId = order.UserId,
        };
    }


    public static OrderFilterData MapFilterData(this Order order,
        ShopContext context)
    {
        var userFullName = context.Users
            .Where(r => r.Id == order.UserId)
            .Select(u => $"{u.Name} {u.Family}")
            .First();
        return new OrderFilterData()
        {
            
            Id = order.Id,
            Status = order.Status,
            CreationDate = order.CreateDate,
            City=order.Address?.City,
            ShippingType=order.ShippingMethod.ShippingType,
            Shir=order.Address?.Shir,
            TotalItemCount=order.ItemCount,
            TotalPrice=order.TotalPrice,
            UserFullName= userFullName,
            UserId=order.UserId,

        };
    }

    public static async Task<List<OrderItemDto>> GetOrderItems(this OrderDto orderDto, DapperContext dapperContext)
    {
        using var connection = dapperContext.CreateConnection();
        var sql = @$"SELECT o.Id, s.ShopName ,o.OrderId,o.InventoryId,o.Count,o.price,
                          p.Title as ProductTitle , p.Slug as ProductSlug ,
                          p.ImageName as ProductImageName
                    FROM {dapperContext.OrderItems} o
                    Inner Join {dapperContext.Inventories} i on o.InventoryId=i.Id
                    Inner Join {dapperContext.Products} p on i.ProductId=p.Id
                    Inner Join {dapperContext.Sellers} s on i.SellerId=s.Id
                    where o.OrderId=@orderId";

        var result = await connection.QueryAsync<OrderItemDto>(sql, new { orderId = orderDto.Id });
        return result.ToList();
    
    }
}

