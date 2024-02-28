
using Common.Query;
using MediatR;
using Shop.Query.Comments.DTos;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetByFilter;

public class GetOrderByFilterQuery : QueryFilter<OrderFilterResult, OrderFilterParam>
    
{
    public GetOrderByFilterQuery(OrderFilterParam filterParams) : base(filterParams)
    {
    }
}
