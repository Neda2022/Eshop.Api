

using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.DTos;


namespace Shop.Query.Comments.GetByFilter;

internal class GetCommentByFilterQueryHandler :
    IQueryHandler<GetCommentByFilterQuery, CommentFilterResult>
{
    private readonly ShopContext _context;

    public GetCommentByFilterQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<CommentFilterResult> Handle(GetCommentByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var result = _context.Comments.OrderByDescending(
            d => d.CreateDate).AsQueryable();

        if(@params.CommentStatus != null)

                result=result.Where(r=>
                r.Status==@params.CommentStatus);

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
        var model = new CommentFilterResult()
        {
            Data = await result.Skip(skip).Take(@params.Take)
                .Select(comment => comment.MapFilterComment())
                .ToListAsync(cancellationToken),
            FilterParams = @params
        };
        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;
       
    }

}


