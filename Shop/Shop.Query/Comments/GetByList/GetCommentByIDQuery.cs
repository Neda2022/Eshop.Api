

using Common.Query;
using Shop.Query.Comments.DTos;

namespace Shop.Query.Comments.GetByList;

public record GetCommentByIDQuery(long commentId):IQuery<CommentDto?>;
