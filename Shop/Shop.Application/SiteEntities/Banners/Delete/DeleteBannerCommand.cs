

using Common.Application;
using FluentValidation;
using Shop.Domain.Entities.SiteEntity.Repository;

namespace Shop.Application.SiteEntities.Banners.Delete;

    public record DeleteBannerCommand(long Id):IBaseCommand;

internal class DeleteBannerCommandHandler : IBaseCommandHandler<DeleteBannerCommand>
{
    private readonly IBannerRepository _repository;

    public DeleteBannerCommandHandler(IBannerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = await _repository.GetTracking(request.Id);
        if (banner == null) { OperationResult.NotFound(); }

        _repository.del
    }
}
