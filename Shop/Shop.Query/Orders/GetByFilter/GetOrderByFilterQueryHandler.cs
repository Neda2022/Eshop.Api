
using Common.Query;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;
using System.Data.Entity;

namespace Shop.Query.Orders.GetByFilter;

public class GetOrderByFilterQueryHandler : IQueryHandler<GetOrderByFilterQuery, OrderFilterResult>
{
    private readonly ShopContext _context;

    public GetOrderByFilterQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<OrderFilterResult> Handle(GetOrderByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var result = _context.Orders.OrderByDescending(d => d.Id).AsQueryable();


        if (@params.Status != null)

            result = result.Where(r =>
            r.Status == @params.Status);

        if (@params.UserId != null)

            result = result.Where(r =>
            r.UserId == @params.UserId);
        // کوئری گرفتن در بازه زمانی
        if (@params.StartDate != null)

            result = result.Where(r =>
            r.CreateDate.Date >= @params.StartDate.Value.Date);

        if (@params.EndtDate != null)

            result = result.Where(r =>
            r.CreateDate.Date >= @params.EndtDate.Value.Date);


        var skip = (@params.PageId - 1) * @params.Take;
        var model = new OrderFilterResult()
        {
            Data = await result.Skip(skip).Take(@params.Take)
                .Select(order => order.MapFilterData(_context))
                .ToListAsync(cancellationToken),
            FilterParams = @params
        };
        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;
    }
}