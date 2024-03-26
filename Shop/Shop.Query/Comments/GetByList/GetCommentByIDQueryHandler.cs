

using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.DTos;


namespace Shop.Query.Comments.GetByList;

internal class GetCommentByIDQueryHandler : IQueryHandler<GetCommentByIdQuery, CommentDto?>
{
    private readonly ShopContext _context;

    public GetCommentByIDQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<CommentDto?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {

        var comment =await _context.Comments.FirstOrDefaultAsync(f =>
        f.Id == request.commentId, cancellationToken);
        return comment.Map();
    }
}
