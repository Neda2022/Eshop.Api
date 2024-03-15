
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.ProductAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetBySlug;

public class GetProductBySlugQueryHandler : IQueryHandler<GetProductBySlugQuery, ProductDto>
{
    private readonly ShopContext _context;

    public GetProductBySlugQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<ProductDto> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
    {
        var produc = await _context.products.FirstOrDefaultAsync(f => f.Slug == request.Slug);
        var model = produc.Map();
        if (model == null) return null;
        await model.SetCategories(_context);
        return model;

    }
}