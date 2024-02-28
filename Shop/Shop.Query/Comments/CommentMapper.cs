

using Shop.Domain.Entities.CommentAgg;
using Shop.Domain.Entities.ProductAgg;
using Shop.Domain.Entities.UserAgg;
using Shop.Query.Comments.DTos;
using static System.Net.Mime.MediaTypeNames;

namespace Shop.Query.Comments;

internal static class CommentMapper
{
    public static CommentDto? Map(this Comment? comment)
    {
        if (comment == null)
            return null;
        return new CommentDto()
        {
            Id = comment.Id,
            CreationDate = comment.CreateDate,
            Status = comment.Status,
            UserId = comment.UserId,
            ProductId = comment.ProductId,
            Text = comment.Text,

        };
    }

    public static CommentDto MapFilterComment(this Comment? comment)
    {
        if (comment == null)
            return null;
        return new CommentDto()
        {
            Id = comment.Id,
            CreationDate = comment.CreateDate,
            Status = comment.Status,
            UserId = comment.UserId,
            ProductId = comment.ProductId,
            Text = comment.Text,

        };
    }
}
