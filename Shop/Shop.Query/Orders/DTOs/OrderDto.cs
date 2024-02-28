
using Common.Query;
using Common.Query.Filter;
using Shop.Domain.Entities.OrderAgg;
using Shop.Domain.Entities.OrderAgg.Enums;
using Shop.Domain.Entities.OrderAgg.ValueObjects;

namespace Shop.Query.Orders.DTOs;

public class OrderDto:BaseDto
{
    public long UserId { get; set; }
    public string UserFullName { get; set; }
    public OrderStatus Status { get; set; }
    public OrderDisCount? Discount { get; set; }
    public List<OrderItemDto> Items { get; set; }
    public OrderAddress? Address { get; set; }
    public ShippingMethod ShippingMethod { get; set; }

    public DateTime? LastUpdate { get; set; }

}


public class OrderItemDto : BaseDto
{
    public string ProductTitle { get; set; }
    public string ProductSlug { get; set; }
    public string ProductImageName { get; set; }
    public string ShopName { get; set; }
    public long OrderId { get; set; }
    public long InventoryId { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public int TotalPrice => Price * Count;
}

public class OrderFilterData : BaseDto
{
    public long UserId { get; set; }
    public string UserFullName { get; set; }
    public OrderStatus Status { get; set; }
    public string? Shir { get; set; }
    public string? City { get; set; }
    public int TotalPrice { get; set; }
    public int TotalItemCount { get; set; }
    public string? ShippingType { get;  set; }


}


public class OrderFilterParam:BaseFilterParam
{
    public long? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndtDate { get; set; }
    public OrderStatus Status { get; set; }

}
public class OrderFilterResult :BaseFilter<OrderFilterData, BaseFilterParam>
{

}