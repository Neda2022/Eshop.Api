

using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetByFilter;

public class GetSellerByFilterQueryHandler : IQueryHandler<GetSellerByFilterQuery, SellerFilterResult>
{
    private readonly ShopContext _context;

    public GetSellerByFilterQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<SellerFilterResult> Handle(GetSellerByFilterQuery request, CancellationToken cancellationToken)
    {
        var @param = request.FilterParams;
        var result = _context.Sellers.OrderByDescending(s => s.Id).AsQueryable();

        if (!string.IsNullOrWhiteSpace(@param.NationalCode))
            result = result.Where(r => r.NationalCode.Contains(@param.NationalCode));

        if (!string.IsNullOrWhiteSpace(@param.ShopName))
            result = result.Where(r => r.NationalCode.Contains(@param.ShopName));
        var skip = (@param.PageId - 1) * @param.Take;

        var sellerResult = new SellerFilterResult()
        {
            FilterParams = @param,
            Data = await result.Skip(skip).Take(@param.Take)
            .Select(s => s.MapList()).ToListAsync(cancellationToken)
        };
        sellerResult.GeneratePaging(result, param.Take, param.PageId);

        return sellerResult;
    }

    }




