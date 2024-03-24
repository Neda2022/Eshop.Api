
using Common.Query;
using Shop.Domain.Entities.OrderAgg.Enums;

namespace Shop.Query.Orders.DTOs;

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
