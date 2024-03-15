

using Common.Application;
using Common.Application.FileUtil.Interfaces;
using FluentValidation;
using Shop.Application._Utilites;
using Shop.Domain.Entities.SiteEntity.Repository;

namespace Shop.Application.SiteEntities.Banners.Delete;

    public record DeleteBannerCommand(long Id):IBaseCommand;

internal class DeleteBannerCommandHandler : IBaseCommandHandler<DeleteBannerCommand>
{
    private readonly IBannerRepository _repository;

    private readonly IFileService _localFileService;
    public DeleteBannerCommandHandler(IBannerRepository repository, IFileService localFileService)
    {
        _repository = repository;
        _localFileService = localFileService;
    }

    public async Task<OperationResult> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = await _repository.GetTracking(request.Id);
        if (banner == null) { OperationResult.NotFound(); }

        //_repository.Delete(banner);
        await _repository.Save();
        _localFileService.DeleteFile(Directories.BannerImages, banner.ImageName);
        return OperationResult.Success();
    }
}
