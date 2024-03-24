using Common.Query.Filter;
using Shop.Domain.Entities.CommentAgg;

namespace Shop.Query.Comments.DTos;

//Pagination===>
public class CommentFilterParams:BaseFilterParam
{

    public long? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndtDate { get; set; }
    public CommentStatus? CommentStatus { get; set; }



}

