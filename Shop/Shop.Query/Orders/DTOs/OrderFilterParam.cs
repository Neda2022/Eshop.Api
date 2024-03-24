using Common.Query.Filter;
using Shop.Domain.Entities.OrderAgg.Enums;

namespace Shop.Query.Orders.DTOs;

public class OrderFilterParam:BaseFilterParam
{
    public long? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndtDate { get; set; }
    public OrderStatus Status { get; set; }

}
