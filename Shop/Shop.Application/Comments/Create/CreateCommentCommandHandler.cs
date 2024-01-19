

using Common.Application;
using Shop.Domain.Entities.CommentAgg;
using Shop.Domain.Entities.CommentAgg.Repository;

namespace Shop.Application.Comments.Create;

public class CreateCommentCommandHandler : IBaseCommandHandler<CreateCommentCommand>
{
    private readonly ICommentRepository _repository;

    public async Task<OperationResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new Comment(request.UserId, request.ProductId, request.Text);
        _repository.Add(comment);
        await _repository.Save();
        return OperationResult.Success();
    }
}
