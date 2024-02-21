

using Common.Query;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;
using System.Data.Entity;

namespace Shop.Query.Categories.GetById;

internal class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly ShopContext _context;

    public GetCategoryByIdQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.Categories.FirstOrDefaultAsync(f =>
        f.Id == request.CategoryId, cancellationToken);
        
        return model.Map();
    }
}
