﻿
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;


namespace Shop.Query.Categories.GetByParantId;

internal class GetCategoryByParantIdQueryHandler :
                 IQueryHandler<GetCategoryByParantIdQuery, List<ChildCategoryDto>>
{
    private readonly ShopContext _context;

    public GetCategoryByParantIdQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<List<ChildCategoryDto>> Handle(GetCategoryByParantIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.Categories
              .Include(c => c.Childs)
            .Where(f =>
            f.ParantId == request.ParantId)
            .ToListAsync(cancellationToken);
        return model.MapChild();
    }
}
