﻿
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilites;
using Shop.Domain.Entities.ProductAgg;
using Shop.Domain.Entities.ProductAgg.Repository;

namespace Shop.Application.Productes.AddImage;

internal class AddProductImageCommandHandler : IBaseCommandHandler<AddProductImageCommand>
{
    private readonly IProductRepository _repository;
    private readonly IFileService _fileService;

    public AddProductImageCommandHandler(IProductRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(AddProductImageCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetTracking(request.ProductId);
        if(product == null) { return OperationResult.NotFound(); }
        var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductGalleryImage);
        var productImage = new ProductImage(imageName, request.Sequence);
        product.AddImage(productImage);
         _fileService.DeleteFile(Directories.ProductGalleryImage, imageName);
        await _repository.Save();
        return OperationResult.Success();
    }
}

