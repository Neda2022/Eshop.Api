
using Common.Application;
using MediatR;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Query.Comments.DTos;
using Shop.Query.Comments.GetByFilter;
using Shop.Query.Comments.GetByList;
namespace Shop.Presentation.Facade.Comments;

internal class CommentFacad : ICommentFacad
{
    private readonly IMediator _mediator;

    public CommentFacad(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> CreateComment(CreateCommentCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditComment(EditCommentCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<CommentDto?> GetCommentnById(long id)
    {
        return await _mediator.Send(new GetCommentByIdQuery(id));
    }
    public async Task<CommentFilterResult> GetCommentByFilter(CommentFilterParams filterParams)
    {
        return await _mediator.Send(new GetCommentByFilterQuery(filterParams));
    }

    
}
