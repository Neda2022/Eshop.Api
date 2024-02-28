

using Common.Query;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;
using System.Data.Entity;

namespace Shop.Query.Orders.GetById;

internal class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly ShopContext _context;
    private readonly DapperContext _dapperContext;

    public GetOrderByIdQueryHandler(DapperContext dapperContext, ShopContext context)
    {

        _dapperContext = dapperContext;
        _context = context;
    }

    public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders
           .FirstOrDefaultAsync(f => f.Id == request.OrderId, cancellationToken);
        if (order == null)
            return null;

        var orderDto = order.Map();
        orderDto.UserFullName = await _context.Users.Where(f => f.Id == orderDto.UserId)
            .Select(s => $"{s.Name} {s.Family}").FirstAsync(cancellationToken);

        orderDto.Items = await orderDto.GetOrderItems(_dapperContext);
        return orderDto;
    }
}