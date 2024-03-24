

using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetFilter;

public class GetUserByFilterQueryHandler : IQueryHandler<GetUserByFilterQuery, UserFilterResult>
{
    private readonly ShopContext _context;

    public GetUserByFilterQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<UserFilterResult> Handle(GetUserByFilterQuery request, CancellationToken cancellationToken)
    {
       var @param= request.FilterParams;
        var result =  _context.Users.OrderByDescending(f => f.Id).AsQueryable();

        if (!string.IsNullOrWhiteSpace(@param.Email))
            result = result.Where(r => r.Email.Contains(@param.Email));

        if (@param !=null)
            result = result.Where(r => r.Id== @param.Id);

        var skip = (@param.PageId - 1) * @param.Take;
        var model = new UserFilterResult()
        {
            Data = await result.Skip(skip).Take(@param.Take)
                .Select(user => user.MapFilterData()).ToListAsync(cancellationToken),
            FilterParams = @param
        };

        model.GeneratePaging(result, @param.Take, @param.PageId);
        return model;
    }
}



