

using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilites;
using Shop.Domain.Entities.SiteEntity;
using Shop.Domain.Entities.SiteEntity.Repository;

namespace Shop.Application.SiteEntities.Banners.Edit;

internal class EditBannerCommandHandler : IBaseCommandHandler<EditBannerCommand>
{
    private readonly IBannerRepository _repository;
    private readonly IFileService _fileService;

    public EditBannerCommandHandler(IBannerRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = await _repository.GetTracking(request.Id);
        if (banner == null)  
            OperationResult.NotFound();
        // عکس قبلی
        var imageName=banner.ImageName;
        var oldImage = banner.ImageName;
        if (request.ImageFile != null)
        {
            imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);
        }
        banner.Edit(request.Link, imageName, request.Position);
        await _repository.Save();
        DeletOldImage(request.ImageFile, oldImage);

        return OperationResult.Success();

    }
    private void DeletOldImage(IFormFile? imageFile, string oldImage)
    {
        //عکس قدیمی بود
        if (imageFile != null)
        {
            _fileService.DeleteFile(Directories.SliderImages, oldImage);
        }
    }
}
