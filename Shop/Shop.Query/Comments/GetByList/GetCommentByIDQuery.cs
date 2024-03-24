

using Common.Query;
using Shop.Query.Comments.DTos;

namespace Shop.Query.Comments.GetByList;

public record GetCommentByIdQuery(long commentId):IQuery<CommentDto?>;
