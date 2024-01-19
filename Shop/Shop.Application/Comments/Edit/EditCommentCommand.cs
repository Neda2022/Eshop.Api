
using Common.Application;
using Shop.Application.Comments.Create;

namespace Shop.Application.Comments.Edit;

public record EditCommentCommand(long commentId, long UserId,string Text) :IBaseCommand;
