﻿

using Common.Query;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.DTos;
using System.Data.Entity;

namespace Shop.Query.Comments.GetByList;

internal class GetCommentByIDQueryHandler : IQueryHandler<GetCommentByIDQuery, CommentDto?>
{
    private readonly ShopContext _context;

    public GetCommentByIDQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<CommentDto?> Handle(GetCommentByIDQuery request, CancellationToken cancellationToken)
    {

        var comment =await _context.Comments.FirstOrDefaultAsync(f =>
        f.Id == request.commentId, cancellationToken);
        return comment.Map();
    }
}
