
using Common.Application;
using Shop.Domain.Entities.CommentAgg.Repository;

namespace Shop.Application.Comments.ChangeStatus;

public class ChangeCommentStatusCommandHanddler : IBaseCommandHandler<ChangeCommentStatusCommand>
{
    private readonly ICommentRepository _repository;

    public ChangeCommentStatusCommandHanddler(ICommentRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(ChangeCommentStatusCommand request, CancellationToken cancellationToken)
    {
        var comment = await _repository.GetTracking(request.Id);
        if (comment == null)
            return OperationResult.NotFound();
        comment.ChangeStatus(request.Status);
        await _repository.Save();
        return OperationResult.Success();
    }
}

