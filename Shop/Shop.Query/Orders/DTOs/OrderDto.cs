
using Common.Query;
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
