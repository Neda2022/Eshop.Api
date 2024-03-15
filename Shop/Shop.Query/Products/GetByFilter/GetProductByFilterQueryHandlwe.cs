

using Common.Query;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;
using System.Linq;

namespace Shop.Query.Products.GetByFilter;

public class GetProductByFilterQueryHandlwe : IQueryHandler<GetProductByFilterQuery, ProductFilterResult>
{
    private readonly ShopContext _context;

    public GetProductByFilterQueryHandlwe(ShopContext context)
    {
        _context = context;
    }

    public async Task<ProductFilterResult> Handle(GetProductByFilterQuery request, CancellationToken cancellationToken)
    {
        var @param = request.FilterParams;
        var result =  _context.products.OrderByDescending(f => f.Id).AsQueryable();

        if (!string.IsNullOrWhiteSpace(@param.Slug))
            result = result.Where(s => s.Slug == @param.Slug);

        if (!string.IsNullOrWhiteSpace(@param.Title))
            result = result.Where(s => s.Title.Contains(@param.Title));

        if (@param.Id !=null)
            result = result.Where(s => s.Id == @param.Id);

        var skip = (@param.PageId - 1) * @param.Take;
        var model = new ProductFilterResult()
        {
            Data = result.Skip(skip).Take(@param.Take)
            .Select(s=>s.MapListData()).ToList(),

            FilterParams= @param,

        };
        model.GeneratePaging(result, @param.Take, @param.PageId);
        return model;


    }
}

