

using Common.Query;
using Shop.Query.Comments.DTos;

namespace Shop.Query.Comments.GetByFilter;

public class GetCommentByFilterQuery
: QueryFilter<CommentFilterResult, CommentFilterParams>
{
    public GetCommentByFilterQuery(CommentFilterParams filterParams) : base(filterParams)
    {
    }
}


