
using Common.Application;
using FluentValidation;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Edit;
using Shop.Domain.Entities.CommentAgg;

namespace Shop.Application.Comments.ChangeStatus;

public record ChangeCommentStatusCommand(long Id, CommentStatus Status): IBaseCommand;

