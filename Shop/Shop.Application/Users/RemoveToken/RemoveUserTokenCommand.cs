

using Common.Application;
using Shop.Domain.Entities.UserAgg.Repository;

namespace Shop.Application.Users.RemoveToken;

    public record RemoveUserTokenCommand(long UserId,long TokenId):IBaseCommand;


internal class RemoveUserTokenCommandHandler : IBaseCommandHandler<RemoveUserTokenCommand>
{
    private readonly IUserRepository _repository;

    public RemoveUserTokenCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(RemoveUserTokenCommand request, CancellationToken cancellationToken)
    {

        var user = await _repository.GetTracking(request.UserId);
        if (user == null) { return OperationResult.NotFound(); }

        user.RemoveToken(request.TokenId);
        await _repository.Save();
        return OperationResult.Success();
    }
}