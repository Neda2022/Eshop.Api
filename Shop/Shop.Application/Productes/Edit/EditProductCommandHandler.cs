

using AngleSharp.Io;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilites;
using Shop.Domain.Entities.ProductAgg;
using Shop.Domain.Entities.ProductAgg.Repository;
using Shop.Domain.Entities.ProductAgg.Services;

namespace Shop.Application.Productes.Edit;

internal class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
{
    private readonly IProductRepository _repository;
    private readonly IProductDomainService _domainService;
    private readonly IFileService _fileSercvice;

    public EditProductCommandHandler(IProductRepository repository,
        IProductDomainService domainService, IFileService fileSercvice)
    {
        _repository = repository;
        _domainService = domainService;
        _fileSercvice = fileSercvice;
    }

    public async Task<OperationResult> Handle(EditProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetTracking(request.ProductId);
        if (product == null)
            return OperationResult.NotFound();
        product.Edit(request.Title,
            request.Description,
            request.CategoryId,
            request.SubCategoryId, 
            request.SecondarySubCategoryId,
            request.Slug,
            request.SeoData,
            _domainService);
        var oldImage = product.ImageName;
        if (request.ImageFile != null)
        {
            var imageName = await _fileSercvice.SaveFileAndGenerateName(request.ImageFile,
                Directories.ProductImages);
            product.SetProductImage(imageName);
        }

        var specifications = new List<ProductSpecification>();
        request.Specifications.ToList().ForEach(specification =>
        {
            specifications.Add(new ProductSpecification(specification.Key, specification.Value));

        });
        product.SetSpecification(specifications);
        await _repository.Save();
        RmoveOldImage(request.ImageFile,oldImage);
        return OperationResult.Success();


        
    }
    private void RmoveOldImage(IFormFile imageFile, string oldImage)
    {
        if (imageFile != null)
        {
            _fileSercvice.DeleteFile(Directories.ProductImages, oldImage);
        }
    }
}



